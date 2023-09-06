using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs
{
    internal partial class FichaCadastroIndividual
    {
        public class SaidaCidadaoCadastro
        {
            public long MotivoSaidaCidadao { get; set; }

            public long DataObito { get; set; }

            [StringLength(9, ErrorMessage = "Tamanho de campo é de 9 caracteres", MinimumLength = 9)]
            public string NumeroDO { get; set; }
        }

    }
}
