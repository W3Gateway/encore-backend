using Encore.Domain.Core.Extensions;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual;
using System.IO.Compression;
using System.Xml.Serialization;
using Thrift.Protocols;
using Thrift.Transports.Client;

namespace Encore.Domain.Services.ESUS
{
    public class EsusService
    {
        private IHomeRepository _homeRepository;

        public EsusService(IHomeRepository homeRepository) {
            _homeRepository = homeRepository;
        }

        public void gerarXMl()
        {
            var fichaAtendimentoIndividual = new FichaAtendimentoIndividualChild();
            fichaAtendimentoIndividual.AtencaoDomiciliarModalidade = 123;
            fichaAtendimentoIndividual.LocalDeAtendimento = 123;
            fichaAtendimentoIndividual.TipoAtendimento = 123;
            fichaAtendimentoIndividual.CpfCidadao = "75581398901";
            fichaAtendimentoIndividual.DataNascimento = DateTime.Now.AddYears(-10).ToEpoch();
            fichaAtendimentoIndividual.Sexo = 1;
            fichaAtendimentoIndividual.Turno = 1;
            fichaAtendimentoIndividual.ProblemaCondicaoAvaliada = new ProblemaCondicaoAvaliacaoAI()
            {
                Ciaps = new List<string>() { "teste1", "teste2", "teste3" },
                OutroCiap1 = "teste4"
            };
            fichaAtendimentoIndividual.Condutas = new List<long>() { 1, 2, 3 };
            fichaAtendimentoIndividual.DataHoraInicialAtendimento = DateTime.Now.ToEpoch();

            var serializer = new XmlSerializer(typeof(FichaAtendimentoIndividualChild));

            using var writer = new StreamWriter("D:\\workspace\\Encore\\documentos\\fichaAtendimentoIndividual.xml");
            serializer.Serialize(writer, fichaAtendimentoIndividual);
        }

        public void GerarXMLXSD()
        {
            var teste = new CadastroDomiciliarThrift();

            teste.StAnimaisNoDomicilio = true;
            teste.AnimaisNoDomicilio = new List<long>
            {
                128, 129, 130
            };

            teste.CondicaoMoradia = condicaoMoradia();

            teste.EnderecoLocalPermanencia = MenderecoLocalPermanencia();

            teste.Familias = MFamiliasRow();

            teste.InstituicaoPermanencia = MInstituicaoPermanencia();

            teste.Latitude = 123;

            teste.Longitude = 123;

            teste.FichaAtualizada = false;

            teste.QuantosAnimaisNoDomicilio = "";

            teste.StatusTermoRecusa = false;

            teste.TpCdsOrigem = 3;

            teste.Uuid = "2112418-" + Guid.NewGuid().ToString();
            teste.UuidFichaOriginadora = teste.Uuid;
            teste.TipoDeImovel = 1;

            teste.HeaderTransport = new UnicaLotacaoHeaderThrift();
            teste.HeaderTransport.DataAtendimento = DateTime.Now.ToEpoch();
            teste.HeaderTransport.ProfissionalCNS = "728019458970002";
            teste.HeaderTransport.Cnes = "2112418";
            //teste.HeaderTransport.Ine = "TesteINE"; não obrigatório
            teste.HeaderTransport.CboCodigo_2002 = "515105";
            teste.HeaderTransport.CodigoIbgeMunicipio = "3138203";

            try
            {
                var teste2 = MontarProtocolo(teste);

                SalvarObjetoComoBinario(teste2.Result, "XmlFiles/teste.esus");
                ZiparPasta("XmlFiles", "xmlzip");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

       // private async Task<byte[]> MontarProtocolo(CadastroIndividualThrift teste)
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
                CnesDadoSerializado = "2112418",
                CodIbge = "3138203",
                DadoSerializado = bytes,
                Originadora = dado,
                Remetente = dado,
                TipoDadoSerializado = 3,
                UuidDadoSerializado = "2112418-" + Guid.NewGuid().ToString(),
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

        //public void LerBinario()
        //{
        //    string inputFilePath = "path/to/your/input/file.bin";

        //    // Caminho do arquivo de texto de saída
        //    string outputFilePath = "path/to/your/output/file.txt";

        //    // Deserializar do formato TBinaryProtocol
        //    MyDataStructure myData;
        //    using (var fileStream = new FileStream(inputFilePath, FileMode.Open))
        //    {
        //        var transport = new TBufferedTransport(new TStreamTransport(fileStream, fileStream));
        //        var protocol = new TBinaryProtocol(transport.);

        //        myData = new MyDataStructure();
        //        myData.Read(protocol);
        //    }

        //    // Converter a estrutura de dados para texto
        //    string textRepresentation = myData.ToString();

        //    // Salvar o texto no arquivo de saída
        //    File.WriteAllText(outputFilePath, textRepresentation);

        //    Console.WriteLine("Conversão concluída. Texto salvo em: " + outputFilePath);
        //}

        public static void SalvarObjetoComoBinario(byte[] objeto, string caminhoArquivo)
        {
            try
            {
                using (FileStream fileStream = new FileStream(caminhoArquivo, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(objeto, 0, objeto.Length);
                }

                Console.WriteLine("Arquivo salvo com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar o arquivo: " + ex.Message);
            }


            //string caminhoPasta = Path.GetDirectoryName(caminhoArquivo);

            //if (!Directory.Exists(caminhoPasta))
            //{
            //    Directory.CreateDirectory(caminhoPasta);
            //}

            //XmlSerializer serializer = new XmlSerializer(typeof(T));
            //using (FileStream stream = new FileStream(caminhoArquivo, FileMode.Create))
            //{
            //    using (StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false))) // false para não emitir o BOM (Byte Order Mark)
            //    {
            //        serializer.Serialize(writer, objeto);
            //    }
            //}
        }

        //public static void SalvarObjetoComoXml<T>(T objeto, string caminhoArquivo)
        //{
        //    string caminhoPasta = @"XmlFiles";  // Altere para o caminho desejado

        //    if (!Directory.Exists(caminhoPasta))
        //    {
        //        Directory.CreateDirectory(caminhoPasta);
        //    }

        //    XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    using (FileStream stream = new FileStream(caminhoArquivo, FileMode.Create))
        //    {
        //        serializer.Serialize(stream, objeto);
        //    }
        //}

        public static CadastroDomiciliarThrift LoadFromXMLString(string xmlText)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(CadastroDomiciliarThrift));
                return serializer.Deserialize(stringReader) as CadastroDomiciliarThrift;
            }
        }

        public static void ZiparPasta(string pastaOrigem, string arquivoDestino)
        {
            if (File.Exists(arquivoDestino))
            {
                File.Delete(arquivoDestino); // Apaga o arquivo zip se ele já existir
            }

            ZipFile.CreateFromDirectory(pastaOrigem, arquivoDestino);
        }

        private InstituicaoPermanenciaThrift MInstituicaoPermanencia()
        {
            var instituicaoPermanencia = new InstituicaoPermanenciaThrift();

            //instituicaoPermanencia.StOutrosProfissionaisVinculados = true;
            //instituicaoPermanencia.NomeResponsavelTecnico = "Nome Responsavel";
            //instituicaoPermanencia.CnsResponsavelTecnico = "244026015070018";
            //instituicaoPermanencia.CargoInstituicao = "Fodão";

            return instituicaoPermanencia;
        }

        private List<FamiliaRowThrift> MFamiliasRow()
        {
            var familiaRowTransports = new List<FamiliaRowThrift>();

            var familiaRowTrans = new FamiliaRowThrift();

            familiaRowTrans.DataNascimentoResponsavel = DateTime.Now.AddYears(-25).ToEpoch();
            familiaRowTrans.NumeroCnsResponsavel = "947323539470000";
            familiaRowTrans.CpfResponsavel = "14082572708";
            familiaRowTrans.NumeroMembrosFamilia = 7;
            familiaRowTrans.NumeroProntuario = "755813989";
            familiaRowTrans.RendaFamiliar = 5;
            familiaRowTrans.ResideDesde = DateTime.Now.AddYears(-5).ToEpoch();
            familiaRowTrans.StMudanca = false;

            familiaRowTransports.Add(familiaRowTrans);

            return familiaRowTransports;
        }

        public CondicaoMoradiaThrift condicaoMoradia()
        {
            var condicaoMoradiaTransport = new CondicaoMoradiaThrift();

            condicaoMoradiaTransport.AbastecimentoAgua = 117;

            //não preenchido por ser urbana
            //condicaoMoradiaTransport.AreaProducaoRural = 1;
    
            condicaoMoradiaTransport.DestinoLixo = 93;   
    
            condicaoMoradiaTransport.FormaEscoamentoBanheiro = 122;

            condicaoMoradiaTransport.Localizacao = 83;

            condicaoMoradiaTransport.MaterialPredominanteParedesExtDomicilio = 109;
            
            condicaoMoradiaTransport.NuComodos = "06";
            condicaoMoradiaTransport.NuMoradores = "07";

            condicaoMoradiaTransport.SituacaoMoradiaPosseTerra = 75;

            condicaoMoradiaTransport.StDisponibilidadeEnergiaEletrica = true;

            condicaoMoradiaTransport.TipoAcessoDomicilio = 89;

            condicaoMoradiaTransport.TipoDomicilio = 85;

            condicaoMoradiaTransport.AguaConsumoDomicilio = 97;
            
            return condicaoMoradiaTransport;
        }

        public EnderecoLocalPermanenciaThrift MenderecoLocalPermanencia()
        {
            var enderecoLocalPermanencia = new EnderecoLocalPermanenciaThrift();

            enderecoLocalPermanencia.Bairro = "Centro";
            enderecoLocalPermanencia.Cep = "39830970";
            enderecoLocalPermanencia.CodigoIbgeMunicipio = "3138203";
            enderecoLocalPermanencia.Complemento = "";
            enderecoLocalPermanencia.NomeLogradouro = "Rua Epaminondas Neves Oliveira";
            enderecoLocalPermanencia.Numero = "177";
            enderecoLocalPermanencia.NumeroDneUf = "14";
            enderecoLocalPermanencia.TelefoneContato = "7558139891";
            enderecoLocalPermanencia.TelefoneResidencia = "7558139289";
            enderecoLocalPermanencia.TipoLogradouroNumeroDne = "081";
            enderecoLocalPermanencia.StSemNumero = false;
            enderecoLocalPermanencia.PontoReferencia = "Perto aqui";
            enderecoLocalPermanencia.MicroArea = "";
            enderecoLocalPermanencia.StForaArea = true;

            return enderecoLocalPermanencia;
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
                    CodigoIbgeMunicipioNascimento = "3138203",
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
                    StatusDesejaInformarIdentidadeGenero =  false,
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
                Uuid = "2112418-" + Guid.NewGuid().ToString()
            };

            return fichaCadastroIndividual;
        }

        //public async Task<FileStream> GerarFichasZip()
        //{
        //    var homes = _homeRepository.GetAsync().Result;

        //    List<CadastroDomiciliarThrift> homeList = new List<CadastroDomiciliarThrift>();

        //    foreach (var home in homes)
        //    {
        //        homeList.Add(BuildHome(home));
        //    }
        //}

        //private CadastroDomiciliarThrift BuildHome(Home home)
        //{
        //    var familiaRow = new FamiliaRowThrift();
        //    familiaRow.CpfResponsavel = home.Persons.Where(p => p.)

        //    var cadastroDomiciliar = new CadastroDomiciliarThrift();

        //    cadastroDomiciliar.Familias = home.

        //}
    }    
}
