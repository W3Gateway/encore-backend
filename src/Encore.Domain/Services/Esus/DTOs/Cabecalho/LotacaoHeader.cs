using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.Cabecalho
{
    public class LotacaoHeader
    {
        [Required]
        [StringLength(15, ErrorMessage = "Tamanho de campo é de 15 caracteres", MinimumLength = 15)]
        public string ProfissionalCNS { get; set; }

        [Required]
        public string CboCodigo_2002 { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Tamanho de campo é de 7 caracteres", MinimumLength = 7)]
        public string Cnes { get; set; }

        [StringLength(10, ErrorMessage = "Tamanho de campo é de 10 caracteres", MinimumLength = 10)]
        public string Ine { get; set; }
    }
}
