namespace Encore.Domain.ValueObjects
{
    public class IneligibleConclusionDestination : EsusIntegrationBase<IneligibleConclusionDestination>
    {
        public static IneligibleConclusionDestination ClinicalInstability => new IneligibleConclusionDestination { Code = 1, Description = "Instabilidade clínica" };
        public static IneligibleConclusionDestination NeedPropaedeutic => new IneligibleConclusionDestination { Code = 2, Description = "Necessidade propedêutica" };
        public static IneligibleConclusionDestination OtherReason => new IneligibleConclusionDestination { Code = 3, Description = "Outro motivo" };
        public static IneligibleConclusionDestination AbsenceOfCaregiver => new IneligibleConclusionDestination { Code = 4, Description = "Ausência de cuidador" };
        public static IneligibleConclusionDestination OtherSocialConditions => new IneligibleConclusionDestination { Code = 5, Description = "Outras condições sociais" };
    }
}
