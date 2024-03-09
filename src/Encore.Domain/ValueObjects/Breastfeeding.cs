namespace Encore.Domain.ValueObjects
{
    public class Breastfeeding : EsusIntegrationBase<Breastfeeding>
    {
        public static Breastfeeding Exclusive => new Breastfeeding { Code = 1, Description = "Exclusivo" };
        public static Breastfeeding Predominant => new Breastfeeding { Code = 2, Description = "Predominante" };
        public static Breastfeeding Complementary => new Breastfeeding { Code = 3, Description = "Complementado" };
        public static Breastfeeding Absent => new Breastfeeding { Code = 4, Description = "Inexistente" };
    }
}
