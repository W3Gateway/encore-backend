namespace Encore.Domain.ValueObjects
{
    public class Outcome : EsusIntegrationBase<Outcome>
    {
        public static Outcome VisitDone => new Outcome { Code = 1, Description = "Visita realizada" };
        public static Outcome VisitRefused => new Outcome { Code = 2, Description = "Visita recusada" };
        public static Outcome Absent => new Outcome { Code = 3, Description = "Ausente" };
    }


}
