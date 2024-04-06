namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class KidneyProblem : EsusIntegrationBase<KidneyProblem>
    {
        public static KidneyProblem RenalInsufficiency => new KidneyProblem { Code = 27, Description = "Insuficiencia Renal" };
        public static KidneyProblem Other => new KidneyProblem { Code = 28, Description = "Outro" };
        public static KidneyProblem Unknown => new KidneyProblem { Code = 29, Description = "Não sabe" };
    }
}
