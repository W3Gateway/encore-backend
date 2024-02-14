using Encore.Domain.Core.Validations;
using Encore.Domain.Services.Esus.DTOs.Cabecalho;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaVisitaDomiciliarTerritorial
{
    public class FichaVisitaDomiciliarMaster
    {
        [Required(ErrorMessage = "Campo UuidFicha é obrigatório")]
        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string UuidFicha { get; set; }

        [Required(ErrorMessage = "Campo TpCdsOPrigem é obrigatório")]
        [Range(1, 9, ErrorMessage = "Fora do limite de 1 a 9")]
        public int TpCdsOrigem { get; set; }

        [Required(ErrorMessage = "Campo HeaderTransport é obrigatório")]
        public UnicaLotacaoHeader HeaderTransport { get; set; }

        [Required(ErrorMessage = "Campo VisitasDomiciliares é obrigatório")]
        [MaxItems(99, 0, ErrorMessage = "Fora do limite de 0 a 99")]
        public List<FichaVisitaDomiciliarChild> VisitasDomiciliares { get; set; }
    }
}
