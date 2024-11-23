using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Dtos.FichaAtendimentoIndividual
{
    public class Medicamentos
    {
        [StringLength(20, ErrorMessage = "Excedeu limite de caracteres")]
        public string CodigoCatmat { get; set; }

        [Required(ErrorMessage = "Campo ViaAdministracao é obrigatório")]
        public int ViaAdministracao { get; set; }

        [Required(ErrorMessage = "Campo Dose é obrigatório")]
        public string Dose { get; set; }

        [Required(ErrorMessage = "Campo DoseUnica é obrigatório")]
        public bool DoseUnica { get; set; }

        [Required(ErrorMessage = "Campo UsoContinuo é obrigatório")]
        public bool UsoContinuo { get; set; }

        public int DoseFrequenciaTipo { get; set; }

        [Range(0, 99, ErrorMessage = "Fora do limite de 0 a 99")]
        public int DoseFrequencia { get; set; }

        [Range(0, 999, ErrorMessage = "Fora do limite de 0 a 999")]
        public int DoseFrequenciaQuantidade { get; set; }

        public int DoseFrequenciaUnidadeMedida { get; set; }

        public long DtInicioTratamento { get; set; }

        [Range(0, 999, ErrorMessage = "Fora do limite de 0 a 999")]
        public int DuracaoTratamento { get; set; }

        public int DuracaoTratamentoMedida { get; set; }

        [Required(ErrorMessage = "Campo QuantidadeReceitada é obrigatório")]
        [Range(1, 999, ErrorMessage = "Fora do limite de 1 a 999")]
        public int QuantidadeReceitada { get; set; }
    }
}
