using Encore.Domain.Core.Validations;
using Encore.Domain.Services.Esus.DTOs.Cabecalho;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    public class FichaAtendimentoIndividualMaster
    {
        [Required(ErrorMessage = "Campo HeaderTransport é obrigatório")]
        public VariasLotacoesHeader HeaderTransport { get; set; }

        [Required(ErrorMessage = "Campo AtendimentosIndividuais é obrigatório")]
        [MaxItems(99, 1, ErrorMessage = "Excedeu limite da lista")]
        public List<FichaAtendimentoIndividualChild> AtendimentosIndividuais { get; set; }

        [Required(ErrorMessage = "Campo UuidFicha é obrigatório")]
        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string UuidFicha { get; set; }

        [Required(ErrorMessage = "Campo TpCdsOPrigem é obrigatório")]
        [Range(1, 9, ErrorMessage = "Fora do limite de 1 a 9")]
        public int TpCdsOrigem { get; set; }
    }
}
