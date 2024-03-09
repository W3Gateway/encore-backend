namespace Encore.Domain.ValueObjects
{
    public class WaterSupply : EsusIntegrationBase<WaterSupply>
    {
        public static WaterSupply PipedWater => new WaterSupply { Code = 117, Description = "Rede encanada até o domicílio" };
        public static WaterSupply WellSpring => new WaterSupply { Code = 118, Description = "Poço/Nascente no domicílio" };
        public static WaterSupply Cistern => new WaterSupply { Code = 119, Description = "Cisterna" };
        public static WaterSupply WaterTruck => new WaterSupply { Code = 120, Description = "Carro pipa" };
        public static WaterSupply Other => new WaterSupply { Code = 121, Description = "Outro" };
    }
}
