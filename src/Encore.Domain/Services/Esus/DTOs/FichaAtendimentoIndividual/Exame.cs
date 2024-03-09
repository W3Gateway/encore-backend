using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    public class Exame
    {
        [Required(ErrorMessage = "Campo CodigoExame é obrigatório")]
        public string CodigoExame { get; set; }

        [MaxItems(2, ErrorMessage = "Excedeu limite da lista")]
        public List<string> SolicitadoAvaliado { get; set; }
    }
}
