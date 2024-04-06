namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class MealFrequency : EsusIntegrationBase<MealFrequency>
    {
        public static MealFrequency Once => new MealFrequency { Code = 34, Description = "uma vez" };
        public static MealFrequency TwoOrThreeTimes => new MealFrequency { Code = 35, Description = "Duas ou três vezes" };
        public static MealFrequency MoreThanThreeTimes => new MealFrequency { Code = 36, Description = "Mais que três vezes" };
    }
}
