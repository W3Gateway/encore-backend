using Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual;
using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;
using Thrift.Protocols;
using Thrift.Transports.Client;

namespace Encore.Domain.Services.ESUS
{
    public class EsusService
    {
        public void gerarXMl()
        {
            var fichaAtendimentoIndividual = new FichaAtendimentoIndividualChild();
            fichaAtendimentoIndividual.AtencaoDomiciliarModalidade = 123;
            fichaAtendimentoIndividual.LocalDeAtendimento = 123;
            fichaAtendimentoIndividual.TipoAtendimento = 123;
            fichaAtendimentoIndividual.CpfCidadao = "12345678901";
            fichaAtendimentoIndividual.DataNascimento = DateTime.Now.AddYears(-10).Ticks;
            fichaAtendimentoIndividual.Sexo = 1;
            fichaAtendimentoIndividual.Turno = 1;
            fichaAtendimentoIndividual.ProblemaCondicaoAvaliada = new ProblemaCondicaoAvaliacaoAI()
            {
                Ciaps = new List<string>() { "teste1", "teste2", "teste3" },
                OutroCiap1 = "teste4"
            };
            fichaAtendimentoIndividual.Condutas = new List<long>() { 1, 2, 3 };
            fichaAtendimentoIndividual.DataHoraInicialAtendimento = DateTime.Now.Ticks;

            var serializer = new XmlSerializer(typeof(FichaAtendimentoIndividualChild));

            using var writer = new StreamWriter("D:\\workspace\\Encore\\documentos\\fichaAtendimentoIndividual.xml");
            serializer.Serialize(writer, fichaAtendimentoIndividual);
        }


        public void GerarXMLXSD()
        {
            var teste = new CadastroDomiciliarThrift();

            teste.AnimaisNoDomicilio = new List<long>
            {
                123, 1235, 1234
            };

            teste.CondicaoMoradia = condicaoMoradia();
            teste.EnderecoLocalPermanencia = MenderecoLocalPermanencia();
            
            teste.Latitude = 123;

            teste.Longitude = 123;

            teste.Familias = MFamiliasRow();

            teste.FichaAtualizada = true;

            teste.QuantosAnimaisNoDomicilio = "";
            teste.StAnimaisNoDomicilio = true;

            teste.StatusTermoRecusa = true;

            teste.TpCdsOrigem = 1;

            teste.Uuid = Guid.NewGuid().ToString();
            teste.UuidFichaOriginadora = "";
            teste.TipoDeImovel = 1;


            teste.InstituicaoPermanencia = MInstituicaoPermanencia();

            teste.HeaderTransport = new UnicaLotacaoHeaderThrift();
                teste.HeaderTransport.DataAtendimento = DateTime.Now.Ticks;
                teste.HeaderTransport.ProfissionalCNS = "profissionalCNS";
                teste.HeaderTransport.Cnes = "cnes";
                teste.HeaderTransport.CboCodigo_2002 = "testecbo";
                teste.HeaderTransport.CodigoIbgeMunicipio = "123456";
                teste.HeaderTransport.Ine = "TesteINE";


            teste.EnderecoLocalPermanencia = new EnderecoLocalPermanenciaThrift();

            try
            {
                var teste2 = MontarProtocolo(teste);

                SalvarObjetoComoXml(teste2.Result, "XmlFiles/teste.xml");
                ZiparPasta("XmlFiles", "xmlzip");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task<DadoTransporteThrift> MontarProtocolo(CadastroDomiciliarThrift teste)
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
                Fone = "123456789",
                NomeBancoDados = "DBENCORE",
                NomeOuRazaoSocial = "Paulo Cedro",
                UuidInstalacao = Guid.NewGuid().ToString(),
                VersaoSistema = "1.0"
            };

            DadoTransporteThrift dadoTransporteThrift = new DadoTransporteThrift()
            {
                CnesDadoSerializado = "1234567",
                CodIbge = "3138203",
                DadoSerializado = bytes,
                Originadora = dado,
                Remetente = dado,
                TipoDadoSerializado = 3,
                UuidDadoSerializado = Guid.NewGuid().ToString(),
                Versao = new VersaoThrift()
                {
                    Major = 5,
                    Revision = 3,
                    Minor = 0
                }
            };

            UnicaLotacaoHeaderThrift unicaLotacaoHeaderThrift = new UnicaLotacaoHeaderThrift()
            {
                CboCodigo_2002 = "",
                Cnes = "",
                CodigoIbgeMunicipio = "",
                DataAtendimento = DateTime.Now.Ticks,
                Ine = "",
                ProfissionalCNS = ""
            };

            //await dado.WriteAsync(protocol, CancellationToken.None);
            //await lotacao.WriteAsync(protocol, CancellationToken.None);

            return dadoTransporteThrift;
        }

        public static void SalvarObjetoComoXml<T>(T objeto, string caminhoArquivo)
        {
            string caminhoPasta = Path.GetDirectoryName(caminhoArquivo);

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false))) // false para não emitir o BOM (Byte Order Mark)
                {
                    serializer.Serialize(writer, objeto);
                }
            }
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

            instituicaoPermanencia.NomeInstituicaoPermanencia= "";
            instituicaoPermanencia.StOutrosProfissionaisVinculados = true;          
            instituicaoPermanencia.NomeResponsavelTecnico = "NomeResponsavel";
            instituicaoPermanencia.CnsResponsavelTecnico = "";
            instituicaoPermanencia.CargoInstituicao = "Fodão";
            instituicaoPermanencia.TelefoneResponsavelTecnico = "";

            return instituicaoPermanencia;
        }

        private List<FamiliaRowThrift> MFamiliasRow()
        {
            var familiaRowTransports = new List<FamiliaRowThrift>();

            var familiaRowTrans = new FamiliaRowThrift();

            familiaRowTrans.DataNascimentoResponsavel = 1;           
            familiaRowTrans.NumeroCnsResponsavel = "";
            familiaRowTrans.CpfResponsavel = "";
            familiaRowTrans.NumeroMembrosFamilia = 3;
            familiaRowTrans.NumeroProntuario = "";
            familiaRowTrans.RendaFamiliar = 1234;
            familiaRowTrans.ResideDesde = 123;
            familiaRowTrans.StMudanca = true;

            familiaRowTransports.Add(familiaRowTrans);

            return familiaRowTransports;
        }

        public CondicaoMoradiaThrift condicaoMoradia()
        {
            var condicaoMoradiaTransport = new CondicaoMoradiaThrift();

            condicaoMoradiaTransport.AbastecimentoAgua = 123;

            condicaoMoradiaTransport.AreaProducaoRural = 1;
    
            condicaoMoradiaTransport.DestinoLixo = 2;   
    
            condicaoMoradiaTransport.FormaEscoamentoBanheiro = 3;

            condicaoMoradiaTransport.Localizacao = 4;

            condicaoMoradiaTransport.MaterialPredominanteParedesExtDomicilio = 5;
            
            condicaoMoradiaTransport.NuComodos = "6";
            condicaoMoradiaTransport.NuMoradores = "7";

            condicaoMoradiaTransport.SituacaoMoradiaPosseTerra = 8;

            condicaoMoradiaTransport.StDisponibilidadeEnergiaEletrica = true;

            condicaoMoradiaTransport.TipoAcessoDomicilio = 9;

            condicaoMoradiaTransport.TipoDomicilio = 10;

            condicaoMoradiaTransport.AguaConsumoDomicilio = 10;
            
            return condicaoMoradiaTransport;
        }

        public EnderecoLocalPermanenciaThrift MenderecoLocalPermanencia()
        {
            var enderecoLocalPermanencia = new EnderecoLocalPermanenciaThrift();

            enderecoLocalPermanencia.Bairro = "Jardim Glória";
            enderecoLocalPermanencia.Cep = "37209272";
            enderecoLocalPermanencia.CodigoIbgeMunicipio = "3138203";
            enderecoLocalPermanencia.Complemento = "";
            enderecoLocalPermanencia.NomeLogradouro = "Rua";
            enderecoLocalPermanencia.Numero = "177";
            enderecoLocalPermanencia.NumeroDneUf = "";
            enderecoLocalPermanencia.TelefoneContato = "123456789";
            enderecoLocalPermanencia.TelefoneResidencia = "123456789";
            enderecoLocalPermanencia.TipoLogradouroNumeroDne = "";
            enderecoLocalPermanencia.StSemNumero = true;
            enderecoLocalPermanencia.PontoReferencia = "Perto aqui";
            enderecoLocalPermanencia.MicroArea = "";
            enderecoLocalPermanencia.StForaArea = true;

            return enderecoLocalPermanencia;
        }
    }
}
