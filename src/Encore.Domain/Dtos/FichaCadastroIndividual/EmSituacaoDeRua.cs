using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Dtos.FichaCadastroIndividual
{
    public class EmSituacaoDeRua
    {
        [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
        public string GrauParentescoFamiliarFrequentado { get; set; }

        [MaxItems(4, ErrorMessage = "Excedeu limite da lista")]
        public List<long> HigienePessoalSituacaoRua { get; set; }

        [MaxItems(5, ErrorMessage = "Excedeu limite da lista")]
        public List<long> OrigemAlimentoSituacaoRua { get; set; }

        [StringLength(100, ErrorMessage = "Excedeu limite de caracteres")]
        public string OutraInstituicaoQueAcompanha { get; set; }

        public long QuantidadeAlimentacoesAoDiaSituacaoRua { get; set; }

        public bool StatusAcompanhadoPorOutraInstituicao { get; set; }

        public bool StatusPossuiReferenciaFamiliar { get; set; }

        public bool StatusRecebeBeneficio { get; set; }

        public bool StatusSituacaoRua { get; set; }

        public bool StatusTemAcessoHigienePessoalSituacaoRua { get; set; }

        public bool StatusVisitaFamiliarFrequentemente { get; set; }

        public long TempoSituacaoRua { get; set; }
    }
}
