namespace Encore.Domain.ValueObjects
{
    public class WaterComsumption: EsusIntegrationBase<WaterComsumption>
    {
        public static WaterComsumption Filter => new WaterComsumption { Code = 97, Description = "Filtrada" };
        public static WaterComsumption Boiled => new WaterComsumption { Code = 98, Description = "Fervida" };
        public static WaterComsumption Chlorinated => new WaterComsumption { Code = 99, Description = "Clorada" };
        public static WaterComsumption Mineral => new WaterComsumption { Code = 152, Description = "Mineral" };
        public static WaterComsumption NoTreatment => new WaterComsumption { Code = 100, Description = "Sem tratamento" };
    }
}