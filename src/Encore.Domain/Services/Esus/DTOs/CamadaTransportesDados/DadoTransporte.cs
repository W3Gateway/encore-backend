using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.CamadaTransportesDados
{
    internal class DadoTransporte
    {
        [Required]
        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string UuidDadoSerializado { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "Fora do limite de 1 a 99")]
        public long TipoDadoSerializado { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Tamanho de campo é de 7 caracteres", MinimumLength = 7)]
        public string CnesDadoSerializado { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Tamanho de campo é de 7 caracteres", MinimumLength = 7)]
        public string CodIbge { get; set; }

        [StringLength(10, ErrorMessage = "Tamanho de campo é de 10 caracteres", MinimumLength = 10)]
        public string IneDadoSerializado { get; set; }

        public long NumLote { get; set; }

        [Required]
        public byte[] DadoSerializado { get; set; }

        [Required]
        public DadoInstalacao Remetente { get; set; }

        [Required]
        public DadoInstalacao Originadora { get; set; }

        [Required]
        public string Versao { get; set; } = "5.0.5";
    }
}
