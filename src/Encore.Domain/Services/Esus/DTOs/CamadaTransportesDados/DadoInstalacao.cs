using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.CamadaTransportesDados
{
    internal class DadoInstalacao
    {
        /// <summary>
        /// Identifica o software que gerou o dado (pec/cds, cdsOff ou software de terceiros)
        /// </summary>
        [Required]
        public string ContraChave { get; set; }

        /// <summary>
        /// É um identificador da instalação do software que gerou o dado. Seja ele o e-SUS ou software de terceiro. Cada e-SUS possui um UUID.
        /// </summary>
        [Required]
        public string UuidInstalacao { get; set; }

        /// <summary>
        /// CPF do responsável ou CNPJ da empresa responsável.
        /// </summary>
        [Required]
        [StringLength(15, ErrorMessage = "Fora do limite de caracteres de 11 a 15", MinimumLength = 11)]
        public string CpfOuCnpj { get; set; }

        /// <summary>
        /// Nome do responsável ou razão social da empresa responsável.
        /// </summary>
        [Required]
        public string NomeOuRazaoSocial { get; set; }

        /// <summary>
        /// Telefone da pessoa ou empresa responsável.
        /// </summary>
        [StringLength(11, ErrorMessage = "Fora do limite de caracteres de 10 a 11", MinimumLength = 10)]
        public string Fone { get; set; }

        /// <summary>
        /// E-mail da pessoa ou empresa responsável.
        /// </summary>
        [StringLength(255, ErrorMessage = "Fora do limite de caracteres de 6 a 255", MinimumLength = 6)]
        public string Email { get; set; }
    }
}
