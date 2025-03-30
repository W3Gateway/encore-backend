using Encore.Domain.Core.Validations;
using Encore.Domain.Dtos.Cabecalho;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Dtos.FichaAtendimentoDomiciliar
{
    public class FichaAtendimentoDomiciliarMaster
    {
        [Required(ErrorMessage = "O campo UuidFicha é obrigatório")]
        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string UuidFicha { get; set; }

        [Required(ErrorMessage = "O Campo TpCdsOrigem é obrigatório")]
        [Range(0, 9, ErrorMessage = "Fora do limite de 0 a 9")]
        public int TpCdsOrigem { get; set; }

        [Required(ErrorMessage = "O campo AtendimentosDomiciliares é obrigatório")]
        [MaxItems(99, ErrorMessage = "Excedeu o limite de 99 itens na lista")]
        public List<FichaAtendimentoDomiciliarChild> AtendimentosDomiciliares { get; set; }

        [Required]
        public VariasLotacoesHeader HeaderTransport { get; set; }
    }
}
