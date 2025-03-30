using Encore.Domain.Core.Extensions;
using Encore.Domain.Models;
using Encore.Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;

namespace Encore.Application.Zip.Handlers
{
    internal class CadastroDomiciliarMock
    {
        public List<byte[]> criaCadastroDomiciliar()
        {
            return new List<byte[]>();
        }

        public CadastroDomiciliarThrift createCadastradoDomiciliarMock(Home home)
        {
            var responsavel = home.Persons.FirstOrDefault(x => x.IsHeadFamily);

            var cadastroDomiciliarThrift = new CadastroDomiciliarThrift();

            var update = !home.AddedDate.Equals(home.ModifiedDate);

            var cnes = home.Microregion.HealthCenter.Cnes;

            cadastroDomiciliarThrift.StatusTermoRecusa = false; //validar

            if (responsavel != null)
            {
                var animals = home.Animals.Split(',').ToList().Select(x => Convert.ToInt64(x)).ToList();

                cadastroDomiciliarThrift = new CadastroDomiciliarThrift();

                cadastroDomiciliarThrift.StAnimaisNoDomicilio = animals.Count > 0;
                cadastroDomiciliarThrift.StatusTermoRecusa = false;

                if(home.TypeProperty != null && cadastroDomiciliarThrift.StAnimaisNoDomicilio && !cadastroDomiciliarThrift.StatusTermoRecusa)
                {
                    cadastroDomiciliarThrift.AnimaisNoDomicilio = animals;
                }

                var invalidKindsOfCondicaoMoradia = new List<string>()
                {
                    TipoDeImovel.Comercio.Description,
                    TipoDeImovel.TerrenoBaldio.Description,
                    TipoDeImovel.PontoEstrategico.Description,
                    TipoDeImovel.Escola.Description,
                    TipoDeImovel.Creche.Description,
                    TipoDeImovel.EstabelecimentoReligioso.Description,
                    TipoDeImovel.CASAI.Description,
                    TipoDeImovel.Outros.Description,
                };

                if (!cadastroDomiciliarThrift.StatusTermoRecusa &&
                    home.TypeProperty != null &&
                    invalidKindsOfCondicaoMoradia.Contains(home.TypeProperty))
                {
                    cadastroDomiciliarThrift.CondicaoMoradia = CreateConditionReport(home);
                }

                cadastroDomiciliarThrift.EnderecoLocalPermanencia = CreateAddressLocation(home);
                cadastroDomiciliarThrift.Familias = CreateFamilyReport(home, responsavel);
                cadastroDomiciliarThrift.FichaAtualizada = update; //verificar como fazer
                cadastroDomiciliarThrift.HeaderTransport = CreateHeaderTransport();

                cadastroDomiciliarThrift.InstituicaoPermanencia = MInstituicaoPermanencia(home);

                //Latitude = 0, //não encontrei
                //Longitude = 0, //não encontrei

                if (home.TypeProperty.Equals(TipoDeImovel.Domicilio.Description) &&                    
                    !cadastroDomiciliarThrift.StatusTermoRecusa)
                {
                    cadastroDomiciliarThrift.StAnimaisNoDomicilio = home.AmountAnimals > 0;

                    if(cadastroDomiciliarThrift.StAnimaisNoDomicilio &&
                        home.AmountAnimals > 0 &&
                        home.AmountAnimals >= animals.Count)
                    {
                        cadastroDomiciliarThrift.QuantosAnimaisNoDomicilio = home.AmountAnimals.ToString();
                    }                    
                }

                cadastroDomiciliarThrift.StatusGeradoAutomaticamente = false; //validar
                cadastroDomiciliarThrift.TipoDeImovel = TipoDeImovel.Get(Convert.ToInt64(home.LocationType)).Code;
                cadastroDomiciliarThrift.TpCdsOrigem = 3;
                cadastroDomiciliarThrift.Uuid = update ? cnes + "-" + Guid.NewGuid() : cnes + "-" + home.Id; //necessário controlar fichas
                cadastroDomiciliarThrift.UuidFichaOriginadora = cnes + "-" + home.Id;
            }
            else
            {
                cadastroDomiciliarThrift.CondicaoMoradia = CreateConditionReport(home);
                cadastroDomiciliarThrift.EnderecoLocalPermanencia = CreateAddressLocation(home);
                cadastroDomiciliarThrift.FichaAtualizada = update; //verificar como fazer
                cadastroDomiciliarThrift.HeaderTransport = CreateHeaderTransport();
                cadastroDomiciliarThrift.InstituicaoPermanencia = MInstituicaoPermanencia(home);
                //Latitude = 0, //não encontrei
                //Longitude = 0, //não encontrei
                cadastroDomiciliarThrift.StatusGeradoAutomaticamente = false; //validar
                cadastroDomiciliarThrift.StatusTermoRecusa = false; //validar
                cadastroDomiciliarThrift.TipoDeImovel = TipoDeImovel.Get(Convert.ToInt64(home.LocationType)).Code;
                cadastroDomiciliarThrift.TpCdsOrigem = 3;
                cadastroDomiciliarThrift.Uuid = update ? cnes + "-" + Guid.NewGuid() : cnes + "-" + home.Id; //necessário controlar fichas
                cadastroDomiciliarThrift.UuidFichaOriginadora = cnes + "-" + home.Id;
            }

            return cadastroDomiciliarThrift;

            //if()
            //cadastroDomiciliar.AnimaisNoDomicilio

            //return new CadastroDomiciliarThrift
            //{
            //    AnimaisNoDomicilio = new List<long>(),
            //    CondicaoMoradia = createCondicaoMoradiaMock(),
            //    EnderecoLocalPermanencia = createEnderecoLocalPermanenciaMock(),
            //    //Familias = createFamiliaRowMock(),
            //    FichaAtualizada = true,
            //    HeaderTransport = createUnicaLotacaoHeaderMock(),
            //    InstituicaoPermanencia = createInstituicaoPermanenciaMock(),
            //    //Latitude = -21.229046, somente da versão 4.2 pra cima
            //    //Longitude = -45.003247, somente da versão 4.2 pra cima
            //    //QuantosAnimaisNoDomicilio = "0",
            //    //StAnimaisNoDomicilio = false, não preenchido devido as regras de preenchimento
            //    StatusGeradoAutomaticamente = true,
            //    StatusTermoRecusa = true,
            //    TipoDeImovel = 1,
            //    TpCdsOrigem = 3,
            //    Uuid = uuid,
            //    UuidFichaOriginadora = uuid,
            //};
        }

        private CondicaoMoradiaThrift CreateConditionReport(Home home)
        {
            var condicaoMoradia = new CondicaoMoradiaThrift();

            condicaoMoradia.AbastecimentoAgua = WaterSupply.Get(Convert.ToInt64(home.WaterSupply)).Code;

            var invalidKindsOfCondicaoMoradia = new List<string>()
            {
                TipoDeImovel.Abrigo.Description,
                TipoDeImovel.Asilo.Description,
                TipoDeImovel.UnidadePrisional.Description,
                TipoDeImovel.SocioEducacional.Description,
                TipoDeImovel.Delegacia.Description,
                TipoDeImovel.CASAI.Description
            };

            condicaoMoradia.AguaConsumoDomicilio = WaterComsumption.Get(Convert.ToInt64(home.WaterConsumption)).Code;
            condicaoMoradia.DestinoLixo = GarbageDestination.Get(Convert.ToInt64(home.GarbageDestination)).Code;
            condicaoMoradia.FormaEscoamentoBanheiro = FormaDeEscoamentoDoBanheiroOuSanitario.Get(Convert.ToInt64(home.SanitaryDrainage)).Code;
            condicaoMoradia.Localizacao = LocalizacaoDaMoradia.Get(Convert.ToInt64(home.TypeProperty)).Code;

            if (invalidKindsOfCondicaoMoradia.Contains(home.TypeProperty))
            {
                condicaoMoradia.MaterialPredominanteParedesExtDomicilio = MaterialPredominanteNaConstrucao.Get(Convert.ToInt64(home.PredominantMaterial)).Code;
                condicaoMoradia.TipoAcessoDomicilio = TipoDeAcessoAoDomicilio.Get(Convert.ToInt64(home.TypeAccess)).Code;
                condicaoMoradia.TipoDomicilio = TipoDeDomicilio.Get(Convert.ToInt64(home.TypeDomicile)).Code;

                if (!home.LocationType.Equals(LocalizacaoDaMoradia.Urbana))
                {
                    condicaoMoradia.AreaProducaoRural = CondicaoDePosseEUsoDaTerra.Get(Convert.ToInt64(home.RuralProductionArea)).Code;
                }
                if(home.NumberRooms > 0)
                {
                    condicaoMoradia.NuComodos = home.NumberRooms.ToString();
                }                
            }
                   
            condicaoMoradia.NuMoradores = home.NumberMembers > 0 ? home.NumberMembers.ToString() : 1.ToString();

            invalidKindsOfCondicaoMoradia.Remove(TipoDeImovel.CASAI.Description);
            
            if (invalidKindsOfCondicaoMoradia.Contains(home.TypeProperty))
            {
                condicaoMoradia.SituacaoMoradiaPosseTerra = SituacaoMoradia.Get(Convert.ToInt64(home.Situation)).Code;
            }

            condicaoMoradia.StDisponibilidadeEnergiaEletrica = home.Electricity;

            return condicaoMoradia;
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

        // Entender como cadastrar mais de uma família quando houver necessidade
        private List<FamiliaRowThrift> CreateFamilyReport(Home home, Person responsavel)
        {
            var familias = new List<FamiliaRowThrift>();

            var tipoDocumento = responsavel.DocumentType.Equals(1) ? "cpf" : "cns";

            var familia = new FamiliaRowThrift()
            {
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

        private UnicaLotacaoHeaderThrift CreateHeaderTransport()
        {
            return new UnicaLotacaoHeaderThrift()
            {
                CboCodigo_2002 = "225285",
                Cnes = "2209748",
                CodigoIbgeMunicipio = "3139201",
                DataAtendimento = DateTime.Now.ToEpoch(),
                //Ine = ,
                ProfissionalCNS = "700000063961002"
            };
        }

        private InstituicaoPermanenciaThrift MInstituicaoPermanencia(Home home)
        {
            var accountable = home.Microregion.HealthCenter.Accountable;

            var instituicaoPermanencia = new InstituicaoPermanenciaThrift();

            instituicaoPermanencia.StOutrosProfissionaisVinculados = true;
            instituicaoPermanencia.NomeResponsavelTecnico = accountable.Name;
            instituicaoPermanencia.CnsResponsavelTecnico = accountable.Cns;
            instituicaoPermanencia.CargoInstituicao = "";

            return instituicaoPermanencia;
        }


        public CondicaoMoradiaThrift createCondicaoMoradiaMock()
        {
            return new CondicaoMoradiaThrift()
            {
                //AbastecimentoAgua = WaterSupply.PipedWater.Code, não preenchido pelas regras de preenchimento
                //AguaConsumoDomicilio = WaterComsumption.Boiled.Code,
                //AreaProducaoRural = 0, regras aplicadas sobre ser area rural para ser preenchida
                //DestinoLixo = GarbageDestination.Burned.Code,
                //FormaEscoamentoBanheiro = FormaDeEscoamentoDoBanheiroOuSanitario.FossaSeptica.Code,
                //Localizacao = LocalizacaoDaMoradia.Urbana.Code,
                //MaterialPredominanteParedesExtDomicilio = MaterialPredominanteNaConstrucao.MadeiraEmparelhada.Code,
                //NuComodos = "3",
                //NuMoradores = "2",
                //SituacaoMoradiaPosseTerra = SituacaoMoradia.Alugado.Code,
                //StDisponibilidadeEnergiaEletrica = true, não preenchido pelas regras de preenchimento
                //TipoAcessoDomicilio = TipoDeAcessoAoDomicilio.Pavimento.Code,
                //TipoDomicilio = TipoDeDomicilio.House.Code, não preenchido pelas regras de preenchimento
            };
        }

        public EnderecoLocalPermanenciaThrift createEnderecoLocalPermanenciaMock()
        {
            return new EnderecoLocalPermanenciaThrift()
            {
                Bairro = "Jardim Glória",
                Cep = "37209272",
                CodigoIbgeMunicipio = "3138203",
                Complemento = "",
                MicroArea = "11",
                NomeLogradouro = "Rubens Magalhães Paes",
                Numero = "177",
                NumeroDneUf = "14",
                PontoReferencia = "Próximo ao supermercado BH",
                StForaArea = false,
                StSemNumero = false,
                TelefoneContato = "35984642786",
                TelefoneResidencia = "",
                TipoLogradouroNumeroDne = "081",
            };
        }

        public List<FamiliaRowThrift> createFamiliaRowMock()
        {
            var familias = new List<FamiliaRowThrift>();
            var familia = new FamiliaRowThrift()
            {
                CpfResponsavel = "14082572708",
                DataNascimentoResponsavel = new DateTime(1994, 3, 4).Millisecond,
                NumeroCnsResponsavel = "123456789012356",
                NumeroMembrosFamilia = 2,
                NumeroProntuario = "123456",
                RendaFamiliar = 13000,
                ResideDesde = new DateTime(2023, 6, 1).Millisecond,
                StMudanca = false,
            };
            familias.Add(familia);
            return familias;
        }

        public UnicaLotacaoHeaderThrift createUnicaLotacaoHeaderMock()
        {
            return new UnicaLotacaoHeaderThrift()
            {
                CboCodigo_2002 = "225285",
                Cnes = "2209748",
                CodigoIbgeMunicipio = "3139201",
                DataAtendimento = DateTime.Now.Millisecond,
                //Ine = "1234567890",
                ProfissionalCNS = "700000063961002",
            };
        }

        public InstituicaoPermanenciaThrift createInstituicaoPermanenciaMock()
        {
            return new InstituicaoPermanenciaThrift()
            {
                //CargoInstituicao = "Gerente",
                //CnsResponsavelTecnico = "123456789012346",
                //NomeInstituicaoPermanencia = "Hospital",
                //NomeResponsavelTecnico = "Geraldo",
                //StOutrosProfissionaisVinculados = false,
                //TelefoneResponsavelTecnico = "35123456789",
            };
        }


    }
}
