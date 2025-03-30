using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Dtos.FichaCadastroIndividual
{
    public class IdentificacaoUsuarioCidadao
    {
        [StringLength(70, ErrorMessage = "Excedeu limite de caracteres")]
        public bool NomeSocial { get; set; }

        [StringLength(7, ErrorMessage = "Tamanho de campo é de 7 caracteres", MinimumLength = 7)]
        public string CodigoIbgeMunicipioNascimento { get; set; }

        [Required]
        public long DataNascimentoCidadao { get; set; }

        public bool DesconheceNomeMae { get; set; }

        [StringLength(100, ErrorMessage = "Fora do limite de caracteres de 6 a 100", MinimumLength = 6)]
        public string EmailCidadao { get; set; }

        [Required]
        public long NacionalidadeCidadao { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Fora do limite de caracteres de 3 a 70", MinimumLength = 3)]
        public string NomeCidadao { get; set; }

        [StringLength(70, ErrorMessage = "Fora do limite de caracteres de 3 a 70", MinimumLength = 3)]
        public string NomeMaeCidadao { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho de campo é de 15 caracteres", MinimumLength = 15)]
        public string CnsCidadao { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho de campo é de 15 caracteres", MinimumLength = 15)]
        public string CnsResponsavelFamiliar { get; set; }

        [StringLength(11, ErrorMessage = "Fora do limite de caracteres de 10 a 11", MinimumLength = 10)]
        public string TelefoneCelular { get; set; }

        [StringLength(11, ErrorMessage = "Tamanho de campo é de 11 caracteres", MinimumLength = 11)]
        public string NumeroNisPisPasep { get; set; }

        public long PaisNascimento { get; set; }

        [Required]
        public long RacaCorCidadao { get; set; }

        [Required]
        public long SexoCidadao { get; set; }

        public bool StatusEhResponsavel { get; set; }

        public long Etnia { get; set; }

        [StringLength(70, ErrorMessage = "Fora do limite de caracteres de 3 a 70", MinimumLength = 3)]
        public string NomePaiCidadao { get; set; }

        public bool DesconheceNomePai { get; set; }

        public long DtNaturalizacao { get; set; }

        [StringLength(16, ErrorMessage = "Excedeu limite de caracteres")]
        public string PortariaNaturalizacao { get; set; }

        public long DtEntradaBrasil { get; set; }

        public string Microarea { get; set; }

        public bool StForaArea { get; set; }

        [StringLength(11, ErrorMessage = "Tamanho de campo é de 11 caracteres", MinimumLength = 11)]
        public string CpfResponsavelFamiliar { get; set; }
    }
}
