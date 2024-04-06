using AutoMapper;
using Encore.Application.Zip.Queries;
using Encore.Application.Zip.Responses;
using Encore.Domain.Core.Extensions;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Domain.Services.Esus;
using Encore.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IO;
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
        private readonly CadastroDomiciliarService _cadastroDomiciliarService;

        public GetZipTokenHandler(IHomeRepository homeRepository,
            IUserRepository userRepository,
            IMapper mapper,
            CadastroDomiciliarService cadastroDomiciliarService)
        {
            _homeRepository = homeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _cadastroDomiciliarService = cadastroDomiciliarService;
        }
        
        public async Task<ZipResponse> Handle(GetZipByPeriodQuery request, CancellationToken cancellationToken)
        {
            var homesQuery = _homeRepository.Include();
            var homes = homesQuery.Where(x => request.BeginDate < x.AddedDate && x.AddedDate < request.EndDate)
                                .Include(x => x.Persons)
                                .Include(x => x.Microregion)
                                .Include(x => x.Microregion.HealthCenter)
                                .Include(x => x.Microregion.HealthCenter.Accountable)
                                .ToList();

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

                    var teste = new ZipResponse() {
                        File = zipStream.ToArray()
                    };          

                    return _mapper.Map<ZipResponse>(teste);
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            return _mapper.Map<ZipResponse>(null);
        }


        private CadastroDomiciliarThrift CreateHomeReport(Home home)
        {
            var responsavel = home.Persons.FirstOrDefault(x => x.IsHeadFamily);

            var cadastroDomiciliarThrift = new CadastroDomiciliarThrift();

            var update = !home.AddedDate.Equals(home.ModifiedDate);

            var cnes = home.Microregion.HealthCenter.Cnes;                

            if (responsavel != null)
            {
                var animals = home.Animals.Split(',').ToList().Select(x => Convert.ToInt64(x)).ToList();

                cadastroDomiciliarThrift = new CadastroDomiciliarThrift()
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
            }
            else
            {
                cadastroDomiciliarThrift = new CadastroDomiciliarThrift()
                {
                    CondicaoMoradia = CreateConditionReport(home),
                    EnderecoLocalPermanencia = CreateAddressLocation(home),
                    FichaAtualizada = update, //verificar como fazer
                    HeaderTransport = CreateHeaderTransport(),
                    InstituicaoPermanencia = MInstituicaoPermanencia(home),
                    //Latitude = 0, //não encontrei
                    //Longitude = 0, //não encontrei
                    StatusGeradoAutomaticamente = false, //validar
                    StatusTermoRecusa = false, //validar
                    TipoDeImovel = TypeHouse.Get(Convert.ToInt64(home.LocationType)).Code,
                    TpCdsOrigem = 3,
                    Uuid = update ? cnes + "-" + Guid.NewGuid() : cnes + "-" + home.Id, //necessário controlar fichas
                    UuidFichaOriginadora = cnes + "-" + home.Id,
                };
            }             

            return cadastroDomiciliarThrift;
        }

        private UnicaLotacaoHeaderThrift CreateHeaderTransport()
        {
            return new UnicaLotacaoHeaderThrift() {
                CboCodigo_2002 = "515105",
                Cnes = "7558139",
                CodigoIbgeMunicipio = "3132701",
                DataAtendimento = DateTime.Now.ToEpoch(),
                //Ine = ,
                ProfissionalCNS = "160210074410006"
            };
        }

        public CadastroIndividualThrift MontarFicharCadastroIndividual()
        {
            var fichaCadastroIndividual = new CadastroIndividualThrift()
            {
                FichaAtualizada = false,
                HeaderTransport = new UnicaLotacaoHeaderThrift() { },
                IdentificacaoUsuarioCidadao = new IdentificacaoUsuarioCidadaoThrift
                {
                    NomeSocial = "Cidadao Um",
                    CodigoIbgeMunicipioNascimento = "3132701",
                    DataNascimentoCidadao = DateTime.Now.AddYears(-20).ToEpoch(),
                    DesconheceNomeMae = true,
                    EmailCidadao = "cidadao@email.com",
                    NacionalidadeCidadao = 1,
                    NomeCidadao = "Cidadao Um",
                    CpfCidadao = "455.596.470-55",
                    StatusEhResponsavel = true,
                    TelefoneCelular = "75581398914",
                    NumeroNisPisPasep = "75581398912",
                    PaisNascimento = 31,
                    RacaCorCidadao = 1,
                    SexoCidadao = 0,
                    DesconheceNomePai = true,
                    StForaArea = true,
                },
                InformacoesSocioDemograficas = new InformacoesSocioDemograficasThrift
                {
                    StatusTemAlgumaDeficiencia = false,
                    GrauInstrucaoCidadao = 60,
                    OcupacaoCodigoCbo2002 = "516505",
                    StatusDesejaInformarOrientacaoSexual = false,
                    SituacaoMercadoTrabalhoCidadao = 69,
                    StatusDesejaInformarIdentidadeGenero = false,
                    StatusFrequentaBenzedeira = false,
                    StatusFrequentaEscola = false,
                    StatusMembroPovoComunidadeTradicional = false,
                    StatusParticipaGrupoComunitario = false,
                    StatusPossuiPlanoSaudePrivado = false
                },
                InformacoesSocioEconomicas = new InformacoesSocioEconomicasThrift
                {
                    AlimentosAcabaramAntesTerDinheiroComprarMais = false,
                    ComeuAlgunsAlimentosQueTinhaDinheiroAcabou = false,
                },
                StatusCadastroIndividualInativo = false,
                StatusGeradoAutomaticamente = false,
                StatusTermoRecusaCadastroIndividualAtencaoBasica = true,
                TpCdsOrigem = 3,
                Uuid = "7558139-" + Guid.NewGuid().ToString()
            };

            return fichaCadastroIndividual;
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
                Localizacao = LocalizacaoDaMoradia.Get(Convert.ToInt64(home.TypeProperty)).Code,
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


        //Validações
        public bool validaCns12(string cns)
        {
            if (cns.Trim().Count() != 15)
            {
                return (false);
            }

            float soma;
            float resto, dv;
            string pis = "";
            string resultado = "";
            pis = cns.Substring(0, 11);

            soma = (int.Parse(pis.Substring(0, 1)) * 15) +
            (int.Parse(pis.Substring(1, 2)) * 14) +
            (int.Parse(pis.Substring(2, 3)) * 13) +
            (int.Parse(pis.Substring(3, 4)) * 12) +
            (int.Parse(pis.Substring(4, 5)) * 11) +
            (int.Parse(pis.Substring(5, 6)) * 10) +
            (int.Parse(pis.Substring(6, 7)) * 9) +
            (int.Parse(pis.Substring(7, 8)) * 8) +
            (int.Parse(pis.Substring(8, 9)) * 7) +
            (int.Parse(pis.Substring(9, 10)) * 6) +
            (int.Parse(pis.Substring(10, 11)) * 5);

            resto = soma % 11;
            dv = 11 - resto;

            if (dv == 11)
            {
                dv = 0;
            }

            if (dv == 10)
            {
                soma = (int.Parse(pis.Substring(0, 1)) * 15) +
                (int.Parse(pis.Substring(1, 2)) * 14) +
                (int.Parse(pis.Substring(2, 3)) * 13) +
                (int.Parse(pis.Substring(3, 4)) * 12) +
                (int.Parse(pis.Substring(4, 5)) * 11) +
                (int.Parse(pis.Substring(5, 6)) * 10) +
                (int.Parse(pis.Substring(6, 7)) * 9) +
                (int.Parse(pis.Substring(7, 8)) * 8) +
                (int.Parse(pis.Substring(8, 9)) * 7) +
                (int.Parse(pis.Substring(9, 10)) * 6) +
                (int.Parse(pis.Substring(10, 11)) * 5) + 2;

                resto = soma % 11;
                dv = 11 - resto;
                resultado = pis + "001" + (int)dv;
            }
            else
            {
                resultado = pis + "000" + (int)dv;
            }

            if (!cns.Equals(resultado))
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        public bool validaCnsProv789(String cns)
        {
            if (cns.Trim().Count() != 15)
            {
                return (false);
            }

            float dv;
            float resto, soma;

            soma = (int.Parse(cns.Substring(0, 1)) * 15) +
            (int.Parse(cns.Substring(1, 2)) * 14) +
            (int.Parse(cns.Substring(2, 3)) * 13) +
            (int.Parse(cns.Substring(3, 4)) * 12) +
            (int.Parse(cns.Substring(4, 5)) * 11) +
            (int.Parse(cns.Substring(5, 6)) * 10) +
            (int.Parse(cns.Substring(6, 7)) * 9) +
            (int.Parse(cns.Substring(7, 8)) * 8) +
            (int.Parse(cns.Substring(8, 9)) * 7) +
            (int.Parse(cns.Substring(9, 10)) * 6) +
            (int.Parse(cns.Substring(10, 11)) * 5) +
            (int.Parse(cns.Substring(11, 12)) * 4) +
            (int.Parse(cns.Substring(12, 13)) * 3) +
            (int.Parse(cns.Substring(13, 14)) * 2) +
            (int.Parse(cns.Substring(14, 15)) * 1);

            resto = soma % 11;

            if (resto != 0)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }
    }
}

