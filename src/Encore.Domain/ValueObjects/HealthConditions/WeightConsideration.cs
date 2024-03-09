namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class WeightConsideration : EsusIntegrationBase<WeightConsideration>
    {
        public static WeightConsideration Underweight => new WeightConsideration { Code = 21, Description = "Abaixo do peso" };
        public static WeightConsideration AdequateWeight => new WeightConsideration { Code = 22, Description = "Peso adequado" };
        public static WeightConsideration Overweight => new WeightConsideration { Code = 23, Description = "Acima do peso" };
    }
}
