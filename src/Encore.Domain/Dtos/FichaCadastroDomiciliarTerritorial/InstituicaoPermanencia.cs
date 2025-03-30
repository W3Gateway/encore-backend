using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Dtos.FichaCadastroDomiciliarTerritorial
{
    public class InstituicaoPermanencia
    {
        [StringLength(100, ErrorMessage = "Fora do limite de caracteres de 0 a 100", MinimumLength = 0)]
        public string NomeInstituicaoPermanencia { get; set; }

        public bool StOutrosProfissionaisVinculados { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Fora do limite de caracteres de 3 a 70", MinimumLength = 3)]
        public string NomeResponsavelTecnico { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho de campo é de 15 caracteres", MinimumLength = 15)]
        public string CNSResponsavelTecnico { get; set; }

        [StringLength(100, ErrorMessage = "Fora do limite de caracteres de 0 a 100", MinimumLength = 0)]
        public string CargoInstituicao { get; set; }

        [StringLength(11, ErrorMessage = "Fora do limite de caracteres de 10 a 11", MinimumLength = 10)]
        public string TelefoneResponsavelTecnico { get; set; }
    }
}
