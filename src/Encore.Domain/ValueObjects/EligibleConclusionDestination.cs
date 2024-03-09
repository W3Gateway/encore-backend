namespace Encore.Domain.ValueObjects
{
    public class EligibleConclusionDestination : EsusIntegrationBase<EligibleConclusionDestination>
    {
        public static EligibleConclusionDestination AdmissionOwnEMAD => new EligibleConclusionDestination { Code = 1, Description = "Admissão na própria EMAD" };
        public static EligibleConclusionDestination ReferAnotherEMAD => new EligibleConclusionDestination { Code = 2, Description = "Encaminhado para outra EMAD" };
        public static EligibleConclusionDestination ReferBasicCare => new EligibleConclusionDestination { Code = 3, Description = "Encaminhado para a Atenção Básica (AD1)" };
        public static EligibleConclusionDestination OtherReferral => new EligibleConclusionDestination { Code = 4, Description = "Outro encaminhamento" };
    }
}
