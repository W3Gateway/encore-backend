using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaVisitaDomiciliarTerritorial
{
    internal class FichaVisitaDomiciliarChild
    {
        [Required(ErrorMessage = "Campo Turno é obrigatório")]
        public long Turno { get; set; }

        [StringLength(30, ErrorMessage = "Excedeu limite de 30 caracteres")]
        public string NumProtuario { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho do campo é de 15 caracteres", MinimumLength = 15)]
        public string CnsCidadao { get; set; }

        public long DtNascimento { get; set; }

        public long Sexo { get; set; }

        public bool StatusVisitaCompartilhadaOutroProfissional { get; set; }

        [MaxItems(36, ErrorMessage = "Excedeu limite de 36 itens na lista")]
        public List<long> MotivosVisita { get; set; }

        [Required(ErrorMessage = "Campo Desfecho é obrigatório")]
        public long Desfecho { get; set; }

        [StringLength(2, ErrorMessage = "Tamanho do campo é de 2 caracteres", MinimumLength = 2)]
        public string Microarea { get; set; }

        public bool StForaArea { get; set; }

        [Required(ErrorMessage = "Campo TipoDeImovel é obrigatório")]
        public long TipoDeImovel { get; set; }

        [Range(0.5, 500, ErrorMessage = "Fora do limite de 0.5 a 500")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "O campo PesoAcompanhamentoNutricional deve ser um número válido com até 3 casas decimais.")]
        public double PesoAcompanhamentoNutricional { get; set; }

        [Range(20, 250, ErrorMessage = "Fora do limite de 20 a 250")]
        [RegularExpression(@"^\d+(\.\d{1,1})?$", ErrorMessage = "O campo AlturaAcompanhamentoNutricional deve ser um número válido com até 1 casa decimal.")]
        public double AlturaAcompanhamentoNutricional { get; set; }

        [StringLength(11, ErrorMessage = "Tamanho do campo é de 11 caracteres", MinimumLength = 11)]
        public string CpfCidadao { get; set; }

        [Range(0, 999, ErrorMessage = "Fora do limite de 0 a 999")]
        public int PressaoSistolica { get; set; }

        [Range(0, 999, ErrorMessage = "Fora do limite de 0 a 999")]
        public int PressaoDiastolica { get; set; }

        [Range(20, 45, ErrorMessage = "Fora do limite de 20 a 45")]
        [RegularExpression(@"^\d+(\.\d{1,1})?$", ErrorMessage = "O campo Temperatura deve ser um número válido com até 1 casa decimal.")]
        public double Temperatura { get; set; }

        [Range(0, 800, ErrorMessage = "Fora do limite de 0 a 800")]
        public int Glicemia { get; set; }

        public int TipoGlicemia { get; set; }

        [Range(0, 10, ErrorMessage = "Fora do limite de 0 a 10")]
        public double Latitude { get; set; }

        [Range(0, 11, ErrorMessage = "Fora do limite de 0 a 11")]
        public double Longitude { get; set; }

        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string UuidOrigemCadastroDomiciliar { get; set; }
    }
}
