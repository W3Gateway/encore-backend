using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaCadastroDomiciliarTerritorial
{
    internal class FamiliaRow
    {
        public long DataNascimentoResponsavel { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Tamanho de campo é de 15 caracteres", MinimumLength = 15)]
        public string NumerCnsResponsavel { get; set; }

        [Range(0, 99, ErrorMessage = "Fora do limite de 0 a 99")]
        public int NumeroMembrosFamilia { get; set; }

        [StringLength(30, ErrorMessage = "Fora do limite de caracteres de 0 a 30", MinimumLength = 0)]
        public string NumeroProntuario { get; set; }

        public long RendaFamiliar { get; set; }

        public long ResideDesde { get; set; }

        public bool StMudanca { get; set; }
        
        [StringLength(11, ErrorMessage = "Tamanho de campo é de 11 caracteres", MinimumLength = 11)]
        public string CpfResponsavel { get; set; }
    }
}
