namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class FoodSource : EsusIntegrationBase<FoodSource>
    {
        public static FoodSource PopularRestaurant => new FoodSource { Code = 37, Description = "Restaurante popular" };
        public static FoodSource ReligiousGroupDonation => new FoodSource { Code = 38, Description = "Doação de grupos religiosos" };
        public static FoodSource RestaurantDonation => new FoodSource { Code = 39, Description = "Doação de restaurante" };
        public static FoodSource PopularDonation => new FoodSource { Code = 40, Description = "Doação popular" };
        public static FoodSource Other => new FoodSource { Code = 41, Description = "Outro" };
    }

}
