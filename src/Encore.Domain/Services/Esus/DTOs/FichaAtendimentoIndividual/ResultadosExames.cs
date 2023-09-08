using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    internal class ResultadosExames
    {
        [Required(ErrorMessage = "Campo Exame é obrigatório")]
        public string Exame { get; set; }

        public long DataSolicitacao { get; set; }

        [Required(ErrorMessage = "Campo DataRealizacao é obrigatório")]
        public long DataRealizacao { get; set; }

        public long DataResultado { get; set; }

        [Required(ErrorMessage = "Campo ResultadoExame é obrigatório")]
        [MaxItems(3, 1, ErrorMessage = "Fora do limite de 1 a 3")]
        public List<ResultadoExame> ResultadoExame { get; set; }
    }
}
