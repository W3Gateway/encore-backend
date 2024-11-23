using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Dtos.Cabecalho
{
    public class VariasLotacoesHeader
    {
        [Required]
        public LotacaoHeader LotacaoFormPrincipal { get; set; }

        public LotacaoHeader LotacaoFormAtendimentoCompartilhado { get; set; }

        [Required]
        public long DataAtendimento { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "Tamanho de campo é de 7 caracteres", MinimumLength = 7)]
        public string CodigoIbgeMunicipio { get; set; }
    }
}
