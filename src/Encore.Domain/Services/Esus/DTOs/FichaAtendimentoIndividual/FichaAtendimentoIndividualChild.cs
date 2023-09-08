using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    internal class FichaAtendimentoIndividualChild
    {
        [StringLength(30, ErrorMessage = "Fora do limite de caracteres de 0 a 30", MinimumLength = 0)]
        public string NumeroProntuario { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho de campo é de 15 caracteres", MinimumLength = 15)]
        public string Cns { get; set; }

        [Required(ErrorMessage = "Campo DataNascimento é obrigatório")]
        public long DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo LocalDeAtendimento é obrigatório")]
        public long LocalDeAtendimento { get; set; }

        [Required(ErrorMessage = "Campo Sexo é obrigatório")]
        public long Sexo { get; set; }

        [Required(ErrorMessage = "Campo Turno é obrigatório")]
        public long Turno { get; set; }

        [Required(ErrorMessage = "Campo TipoAtendimento é obrigatório")]
        public long TipoAtendimento { get; set; }

        [Range(0.5, 500, ErrorMessage = "Fora do limite de 0.5 a 500")]
        public double PesoAcompanhamentoNutricional { get; set; }

        [Range(2, 5, ErrorMessage = "Fora do limite de 2 a 5")]
        public double AlturaAcompanhamentoNutricional { get; set; }

        public long AleitamentoMaterno { get; set; }

        public long DumDaGestante { get; set; }

        [Range(0, 2, ErrorMessage = "Fora do limite de 0 a 2")]
        public int IdadeGestacional { get; set; }

        public long AtencaoDomiciliarModalidade { get; set; }

        [Required(ErrorMessage = "Campo ProblemaCondicaoAvaliada é obrigatório")]
        public ProblemaCondicaoAvaliacaoAI ProblemaCondicaoAvaliada { get; set; }

        [MaxItems(100, ErrorMessage = "Excedeu limite da lista")]
        public List<Exame> exame { get; set; }

        public bool VacinaEmDia { get; set; }

        public bool FicouEmObservacao { get; set; }

        [MaxItems(3, 0, ErrorMessage = "Fora dos limites da lista de 0 a 3")]
        public List<long> Nasfs { get; set; }

        [Required(ErrorMessage = "Campo Condutas é obrigatório")]
        [MaxItems(12, 1, ErrorMessage = "Fora dos limites da lista de 1 a 12")]
        public List<long> Condutas { get; set; }

        public bool StGravidezPlanejada { get; set; }

        [Range(0, 2, ErrorMessage = "Fora do limite de 0 a 2")]
        public int NuGestasPrevias { get; set; }

        [Range(0, 2, ErrorMessage = "Fora do limite de 0 a 2")]
        public int NuPartos { get; set; }

        [Range(0, 1, ErrorMessage = "Fora do limite de 0 a 1")]
        public long RacionalidadeSaude { get; set; }

        [Range(10, 200, ErrorMessage = "Fora do limite de 10 a 200")]
        public double PerimetroCefalico { get; set; }

        [Required(ErrorMessage = "Campo DataHoraInicialAtendimento é obrigatório")]
        public long DataHoraInicialAtendimento { get; set; }

        [Required(ErrorMessage = "Campo DataHoraFinalAtendimento é obrigatório")]
        public long DataHoraFinalAtendimento { get; set; }

        [StringLength(11, ErrorMessage = "Tamanho do campo é de 11 caracteres", MinimumLength = 11)]
        public string CpfCidadao { get; set; }

        [MaxItems(15, ErrorMessage = "Excedeu limite da lista")]
        public List<Medicamentos> Medicamentos { get; set; }

        [MaxItems(10, ErrorMessage = "Excedeu limite da lista")]
        public List<Encaminhamentos> Encaminhamentos { get; set; }

        [MaxItems(10, ErrorMessage = "Excedeu limite da lista")]
        public List<ResultadosExames> ResultadosExames { get; set; }
    }
}
