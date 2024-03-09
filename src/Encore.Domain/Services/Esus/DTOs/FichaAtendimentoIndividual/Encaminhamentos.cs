using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    public class Encaminhamentos
    {
        [Required(ErrorMessage = "Campo Especialidade é obrigatório")]
        public int Especialidade { get; set; }

        public string HipoteseDiagnosticoCID10 { get; set; }

        public string HipoteseDiagnosticoCIAP2 { get; set; }

        [Required(ErrorMessage = "Campo ClassificacaoRisco é obrigatório")]
        public int ClassificacaoRisco { get; set; }
    }
}
