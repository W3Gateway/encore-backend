using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoDomiciliar
{
    public class FichaAtendimentoDomiciliarChild
    {
        [Required(ErrorMessage = "Campo Turno é obrigatório")]
        public long Turno { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho do campo é de 15 caracteres", MinimumLength = 15)]
        public string CnsCidadao { get; set; }

        [Required(ErrorMessage = "Campo DataNascimento é obrigatório")]
        public long DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo Sexo é obrigatório")]
        public long Sexo { get; set; }

        [Required(ErrorMessage = "Campo LocalDeAtendimento é obrigatório")]
        public long LocalDeAtendimento { get; set; }

        [Required(ErrorMessage = "Campo AtencaoDomiciliarModalidade é obrigatório")]
        public long AtencaoDomiciliarModalidade { get; set; }

        [Required(ErrorMessage = "Campo TipoAtendimento é obrigatório")]
        public long TipoAtendimento { get; set; }

        [MaxItems(24, ErrorMessage = "Excedeu limite de 24 itens na lista")]
        public List<long> CondicoesAvaliadas { get; set; }

        public string Cid { get; set; }
        
        public string Ciap { get; set; }

        [MaxItems(30, ErrorMessage = "Excedeu limite de 30 itens na lista")]
        public List<string> Procedimentos { get; set; }

        [Required(ErrorMessage = "Campo CondutaDesfecho é obrigatório")]
        public long CondutaDesfecho { get; set; }

        [StringLength(11, ErrorMessage = "Tamanho do campo é de 11 caracteres", MinimumLength = 11)]
        public string CpfCidadao { get; set; }
    }
}
