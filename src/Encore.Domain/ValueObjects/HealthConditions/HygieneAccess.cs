namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class HygieneAccess : EsusIntegrationBase<HygieneAccess>
    {
        public static HygieneAccess Bath => new HygieneAccess { Code = 42, Description = "Banho" };
        public static HygieneAccess ToiletAccess => new HygieneAccess { Code = 43, Description = "Acesso a sanitário" };
        public static HygieneAccess OralHygiene => new HygieneAccess { Code = 44, Description = "Higiene bucal" };
        public static HygieneAccess Other => new HygieneAccess { Code = 45, Description = "Outros" };
    }
}
