namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class MealFrequency : EsusIntegrationBase<MealFrequency>
    {
        public static MealFrequency Once => new MealFrequency { Code = 34, Description = "Once" };
        public static MealFrequency TwoOrThreeTimes => new MealFrequency { Code = 35, Description = "Two or three times" };
        public static MealFrequency MoreThanThreeTimes => new MealFrequency { Code = 36, Description = "More than three times" };
    }
}
