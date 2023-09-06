using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs
{
    internal partial class FichaCadastroIndividual
    {
        public class CondicoesDeSaude
        {
            [StringLength(100, ErrorMessage ="Excedeu limite de caracteres")]
            public string DescricaoCausaInternacaoEm12Meses { get; set; }

            [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
            public string DescricaoOutraCondicao1 { get; set; }

            [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
            public string DescricaoOutraCondicao2 { get; set; }

            [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
            public string DescricaoOutraCondicao3 { get; set; }

            [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
            public string DescricaoPlantasMedicinaisUsadas { get; set; }

            [MaxItems(3, ErrorMessage = "Excedeu limite da lista")]
            public List<long> DoencaCardiaca { get; set; }

            [MaxItems(4, ErrorMessage = "Excedeu limite da lista")]
            public List<long> DoencaRespiratoria { get; set; }

            [MaxItems(3, ErrorMessage = "Excedeu limite da lista")]
            public List<long> DoencaRins { get; set; }

            [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
            public string MaternidadeDeReferencia { get; set; }

            public long SituacaoPeso { get; set; }

            public bool StatusEhDependenteOutrasDrogas { get; set; }

            public bool StatusEhFumante { get; set; }

            public bool StatusEhGestante { get; set; }

            public bool StatusEstaAcamado { get; set; }

            public bool StatusEstaDomiciliado { get; set; }

            public bool StatusTemDiabetes { get; set; }

            public bool StatusTemDoencaRespiratoria { get; set; }

            public bool StatusTemHanseniase { get; set; }

            public bool StatusTemHipertensaoArterial { get; set; }

            public bool StatusTemTeveCancer { get; set; }

            public bool StatusTemTuberculose { get; set; }

            public bool StatusTeveAvcDerrame { get; set; }

            public bool StatusTeveDoencaCardiaca { get; set; }

            public bool StatusTeveInfarto { get; set; }

            public bool StatusTeveInternadoem12Meses { get; set; }

            public bool StatusUsaOutrasPraticasIntegrativasOuComplementares { get; set; }

            public bool StatusUsaPlantasMedicinais { get; set; }

            public bool StatusDiagnosticoMental { get; set; }
        }

    }
}
