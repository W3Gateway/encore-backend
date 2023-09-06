using Encore.Domain.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs
{
    internal partial class FichaCadastroIndividual
    {
        public class InformacoesSocioDemograficas
        {
            [MaxItems(5, minItems:1, ErrorMessage = "Excedeu limite da lista")]
            public List<long> DeficienciasCidadao { get; set; }

            public long GrauInstrucaoCidadao { get; set; }

            [StringLength(6, ErrorMessage = "Tamanho de campo é de 6 caracteres", MinimumLength = 6)]
            public string OcupacaoCodigoCbo2002 { get; set; }

            public long OrientacaoSexualCidadao { get; set; }

            public long RelacaoParentescoCidadao { get; set; }

            public long SituacaoMercadoTrabalhoCidadao { get; set; }

            public bool StatusDesejaInformarOrientacaoSexual { get; set; }

            public bool StatusFrequentaBenzedeira { get; set; }

            public bool StatusFrequentaEscola { get; set; }

            public bool StatusMembroPovoComunidadeTradicional { get; set; }

            public bool StatusParticipaGrupoComunitario { get; set; }

            public bool StatusPossuiPlanoSaudePrivado { get; set; }

            public bool StatusTemAlgumaDeficiencia { get; set; }

            public long IdentidadeGeneroCidadao { get; set; }

            public bool StatusDesejaInformarIdentidadeGenero { get; set; }

            [MaxItems(6, ErrorMessage = "Excedeu limite da lista")]
            public List<long> ResponsavelPorCrianca { get; set; }

            public long CoPovoComunidadeTradicional { get; set; }
        }

    }
}
