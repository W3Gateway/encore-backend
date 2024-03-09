namespace Encore.Domain.ValueObjects.Person
{
    public class Nationality : EsusIntegrationBase<Nationality>
    {
        public static Nationality Brazilian => new Nationality { Code = 1, Description = "Brasileira" };
        public static Nationality Naturalized => new Nationality { Code = 2, Description = "Naturalizado" };
        public static Nationality Foreigner => new Nationality { Code = 3, Description = "Estrangeiro" };
    }
}
