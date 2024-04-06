namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class HomelessDuration : EsusIntegrationBase<HomelessDuration>
    {
        public static HomelessDuration LessThanSixMonths => new HomelessDuration { Code = 17, Description = "Menos de 6 meses" };
        public static HomelessDuration SixToTwelveMonths => new HomelessDuration { Code = 18, Description = "6 à 12 meses" };
        public static HomelessDuration OneToFiveYears => new HomelessDuration { Code = 19, Description = "1 à 5 anos" };
        public static HomelessDuration MoreThanFiveYears => new HomelessDuration { Code = 20, Description = "Mais que 5 anos" };
    }
}
