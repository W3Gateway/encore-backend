using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    internal class ResultadoExame
    {
        [Required(ErrorMessage = "Campo TipoResultado é obrigatório")]
        public int TipoResultado { get; set; }

        [Required(ErrorMessage = "Campo ValorResultado é obrigatório")]
        public string ValorResultado { get; set; }
    }
}
