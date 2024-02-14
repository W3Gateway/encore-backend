using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaCadastroDomiciliarTerritorial
{
    public class EnderecoLocalPermanencia
    {
        [Required]
        [StringLength(72, ErrorMessage = "Fora do limite de caracteres de 0 a 72", MinimumLength = 0)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Tamanho de campo é de 8 caracteres", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Tamanho de campo é de 7 caracteres", MinimumLength = 7)]
        public string CodigoIbgeMunicipio { get; set; }

        [StringLength(30, ErrorMessage = "Fora do limite de caracteres de 0 a 30", MinimumLength = 0)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(72, ErrorMessage = "Fora do limite de caracteres de 0 a 72", MinimumLength = 0)]
        public string NomeLogradouro { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Fora do limite de caracteres de 1 a 10", MinimumLength = 1)]
        public string Numero { get; set; }

        [Required]
        public string NumeroDneUf { get; set; }

        [StringLength(11, ErrorMessage = "Fora do limite de caracteres de 10 a 11", MinimumLength = 10)]
        public string TelefoneContato { get; set; }

        [StringLength(11, ErrorMessage = "Fora do limite de caracteres de 10 a 11", MinimumLength = 10)]
        public string TelefoneResidencia { get; set; }

        [Required]
        public string TipoLogradouroNumeroDne { get; set; }

        public bool StSemNumero { get; set; }

        [StringLength(40, ErrorMessage = "Fora do limite de caracteres de 0 a 40", MinimumLength = 0)]
        public string PontoReferencia { get; set; }

        [StringLength(2, ErrorMessage = "Tamanho de campo é de 2 caracteres", MinimumLength = 2)]
        public string MicroArea { get; set; }

        public bool StForaArea { get; set; }
    }
}
