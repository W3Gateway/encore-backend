using AutoMapper;
using Encore.Application.Zip.Queries;
using Encore.Application.Zip.Responses;
using Encore.Domain.Core.Extensions;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Domain.ValueObjects;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IO.Compression;
using Thrift.Protocols;
using Thrift.Transports.Client;

namespace Encore.Application.Zip.Handlers
{
    public class GetZipTokenHandler : IRequestHandler<GetZipByPeriodQuery, ZipResponse>
    {        
        private readonly IHomeRepository _homeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetZipTokenHandler(IHomeRepository homeRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _homeRepository = homeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<ZipResponse> Handle(GetZipByPeriodQuery request, CancellationToken cancellationToken)
        {
            var homes = _homeRepository.Include().Where(x => request.BeginDate < x.AddedDate && x.AddedDate < request.EndDate).ToList();

            var cadastroDomiciliarList = new List<CadastroDomiciliarThrift>();

            if (!homes.IsNullOrEmpty())
            {
                foreach (Home home in homes)
                {
                   cadastroDomiciliarList.Add(CreateHomeReport(home));
                }
            }

            var listaEsusCadastroDomiciliar = new List<byte[]>();

            cadastroDomiciliarList.ForEach(async x => 
            {
                listaEsusCadastroDomiciliar.Add(await MontarProtocolo(x));                
            });

            var nomeArquivo = "ZipFinal.zip";

            try
            {
                using (var zipStream = new MemoryStream())
                {
                    using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < listaEsusCadastroDomiciliar.Count; i++)
                        {
                            var entryName = $"arquivo{i + 1}.esus"; // Nome do arquivo dentro do ZIP
                            var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);

                            using (var entryStream = entry.Open())
                            {
                                await entryStream.WriteAsync(listaEsusCadastroDomiciliar[i]);
                            }
                        }
                    }

                    return _mapper.Map<ZipResponse>(zipStream.ToArray());
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            return _mapper.Map<ZipResponse>(null);
        }


        private CadastroDomiciliarThrift CreateHomeReport(Home home)
        {
            var responsavel = home.Persons.First(x => x.IsHeadFamily);
            var cnes = responsavel.Microregion.HealthCenter.Cnes;

            var animals = home.Animals.Split(',').ToList().Select(x => Convert.ToInt64(x)).ToList();

            var update = !home.AddedDate.Equals(home.ModifiedDate);

            var cadastroDomiciliarThrift = new CadastroDomiciliarThrift()
            {
                AnimaisNoDomicilio = animals,
                CondicaoMoradia = CreateConditionReport(home),
                EnderecoLocalPermanencia = CreateAddressLocation(home),
                Familias = CreateFamilyReport(home, responsavel),
                FichaAtualizada = update, //verificar como fazer
                HeaderTransport = CreateHeaderTransport(),
                InstituicaoPermanencia = MInstituicaoPermanencia(home),
                //Latitude = 0, //não encontrei
                //Longitude = 0, //não encontrei
                QuantosAnimaisNoDomicilio = home.AmountAnimals.ToString(),
                StAnimaisNoDomicilio = home.AmountAnimals > 0,
                StatusGeradoAutomaticamente = false, //validar
                StatusTermoRecusa = false, //validar
                TipoDeImovel = TypeHouse.Get(Convert.ToInt64(home.LocationType)).Code,
                TpCdsOrigem = 3,
                Uuid = update ? cnes + "-" + Guid.NewGuid() : cnes + "-" + home.Id, //necessário controlar fichas
                UuidFichaOriginadora = cnes + "-" + home.Id,
            };          

            return cadastroDomiciliarThrift;
        }

        private UnicaLotacaoHeaderThrift CreateHeaderTransport()
        {
            throw new NotImplementedException();
        }

        private EnderecoLocalPermanenciaThrift CreateAddressLocation(Home home)
        {
            var address = new EnderecoLocalPermanenciaThrift()
            {
                Bairro = home.Address.Neighborhood,
                Cep = home.Address.PostalCode,
                // CodigoIbgeMunicipio = home.Address., não temos código ibge
                Complemento = home.Address.StreetComplement,
                MicroArea = home.Microregion.Name,
                NomeLogradouro = home.Address.Street,
                Numero = home.Address.Number.ToString(),
                //NumeroDneUf = home.Address.St, aguardando cadastro uf
                PontoReferencia = home.Address.Landmark,
                //StForaArea = ,
                StSemNumero = home.Address.Number.ToString().IsNullOrEmpty(),
                TelefoneContato = home.ContactNumber,
                TelefoneResidencia = home.HomeContact,
                //TipoLogradouroNumeroDne = home.HomeContact; aguardar inserir
            };

            return address;
        }

        private CondicaoMoradiaThrift CreateConditionReport(Home home)
        {
            var condicaoMoradia = new CondicaoMoradiaThrift()
            {
                AbastecimentoAgua = WaterSupply.Get(Convert.ToInt64(home.WaterSupply)).Code,
                AguaConsumoDomicilio = WaterComsumption.Get(Convert.ToInt64(home.WaterConsumption)).Code,
                AreaProducaoRural = CondicaoDePosseEUsoDaTerra.Get(Convert.ToInt64(home.RuralProductionArea)).Code,
                DestinoLixo = GarbageDestination.Get(Convert.ToInt64(home.GarbageDestination)).Code,
                FormaEscoamentoBanheiro = FormaDeEscoamentoDoBanheiroOuSanitario.Get(Convert.ToInt64(home.SanitaryDrainage)).Code,
                Localizacao = LocalizacaoDaMoradia.Get(Convert.ToInt64(home.LocationType)).Code,
                MaterialPredominanteParedesExtDomicilio = MaterialPredominanteNaConstrucao.Get(Convert.ToInt64(home.PredominantMaterial)).Code,
                NuComodos = home.NumberRooms.ToString(),
                NuMoradores = home.NumberMembers.ToString(),
                //SituacaoMoradiaPosseTerra = home., não achei
                StDisponibilidadeEnergiaEletrica = home.Electricity,
                TipoAcessoDomicilio = TipoDeAcessoAoDomicilio.Get(Convert.ToInt64(home.TypeAccess)).Code,
                TipoDomicilio = TipoDeDomicilio.Get(Convert.ToInt64(home.TypeDomicile)).Code
            };

            return condicaoMoradia;
        }

        private List<FamiliaRowThrift> CreateFamilyReport(Home home, Person responsavel)
        {
            var familias = new List<FamiliaRowThrift>();            

            var tipoDocumento = responsavel.DocumentType.Equals(1) ? "cpf" : "cns";

            var familia = new FamiliaRowThrift() { 
                StMudanca = false, //não encontrei
                RendaFamiliar = Convert.ToInt64(home.HouseholdIncome),
                CpfResponsavel = tipoDocumento.Equals("cpf") ? responsavel.Document : "",
                DataNascimentoResponsavel = responsavel.BirthDate.ToEpoch(),
                NumeroCnsResponsavel = tipoDocumento.Equals("cns") ? responsavel.Document : "",
                NumeroMembrosFamilia = home.Persons.Count(),
                NumeroProntuario = null == home.MedicalRecordNumber ? "" : home.MedicalRecordNumber,
                ResideDesde = DateTime.Now.ToEpoch(), //não encontrei
            };

            familias.Add(familia);

            return familias;
        }

        private InstituicaoPermanenciaThrift MInstituicaoPermanencia(Home home)
        {
            var accountable = home.Microregion.HealthCenter.Accountable;

            var instituicaoPermanencia = new InstituicaoPermanenciaThrift();
           
            instituicaoPermanencia.StOutrosProfissionaisVinculados = true;
            instituicaoPermanencia.NomeResponsavelTecnico = accountable.Name;
            instituicaoPermanencia.CnsResponsavelTecnico = accountable.Cns;
            instituicaoPermanencia.CargoInstituicao = ""; //descobrir onde tem o cargo 

            return instituicaoPermanencia;
        }

        private async Task<byte[]> MontarProtocolo(CadastroDomiciliarThrift teste)
        {
            TMemoryBufferClientTransport transport = new TMemoryBufferClientTransport();
            TBinaryProtocol protocol = new TBinaryProtocol(transport);

            await teste.WriteAsync(protocol, CancellationToken.None);

            byte[] bytes = transport.GetBuffer();

            DadoInstalacaoThrift dado = new DadoInstalacaoThrift()
            {
                ContraChave = "testeContraChave",
                CpfOuCnpj = "14082572708",
                Email = "teste@teste.com",
                Fone = "755813989",
                NomeBancoDados = "DBENCORE",
                NomeOuRazaoSocial = "Paulo Cedro",
                UuidInstalacao = Guid.NewGuid().ToString(),
                VersaoSistema = "1.0"
            };

            DadoTransporteThrift dadoTransporteThrift = new DadoTransporteThrift()
            {
                CnesDadoSerializado = "7558139",
                CodIbge = "3132701",
                DadoSerializado = bytes,
                Originadora = dado,
                Remetente = dado,
                TipoDadoSerializado = 3,
                UuidDadoSerializado = "7558139-" + Guid.NewGuid().ToString(),
                Versao = new VersaoThrift()
                {
                    Major = 3,
                    Minor = 2,
                    Revision = 3
                }
            };

            TMemoryBufferClientTransport transport2 = new TMemoryBufferClientTransport();
            TBinaryProtocol protocol2 = new TBinaryProtocol(transport2);

            await dadoTransporteThrift.WriteAsync(protocol2, CancellationToken.None);

            //await dado.WriteAsync(protocol, CancellationToken.None);
            //await lotacao.WriteAsync(protocol, CancellationToken.None);

            return transport2.GetBuffer();
        }
    }
}
