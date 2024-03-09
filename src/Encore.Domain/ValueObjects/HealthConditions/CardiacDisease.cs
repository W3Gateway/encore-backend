namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class CardiacDisease : EsusIntegrationBase<CardiacDisease>
    {
        public static CardiacDisease HeartFailure => new CardiacDisease { Code = 24, Description = "Insuficiência cardíaca" };
        public static CardiacDisease Other => new CardiacDisease { Code = 25, Description = "Outro" };
        public static CardiacDisease Unknown => new CardiacDisease { Code = 26, Description = "Não sabe" };
    }
}
