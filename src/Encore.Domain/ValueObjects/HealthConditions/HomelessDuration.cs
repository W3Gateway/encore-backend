namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class HomelessDuration : EsusIntegrationBase<HomelessDuration>
    {
        public static HomelessDuration LessThanSixMonths => new HomelessDuration { Code = 17, Description = "Less than 6 months" };
        public static HomelessDuration SixToTwelveMonths => new HomelessDuration { Code = 18, Description = "6 to 12 months" };
        public static HomelessDuration OneToFiveYears => new HomelessDuration { Code = 19, Description = "1 to 5 years" };
        public static HomelessDuration MoreThanFiveYears => new HomelessDuration { Code = 20, Description = "More than 5 years" };
    }
}
