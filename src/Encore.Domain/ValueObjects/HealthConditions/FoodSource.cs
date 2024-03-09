namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class FoodSource : EsusIntegrationBase<FoodSource>
    {
        public static FoodSource PopularRestaurant => new FoodSource { Code = 37, Description = "Popular restaurant" };
        public static FoodSource ReligiousGroupDonation => new FoodSource { Code = 38, Description = "Religious group donation" };
        public static FoodSource RestaurantDonation => new FoodSource { Code = 39, Description = "Restaurant donation" };
        public static FoodSource PopularDonation => new FoodSource { Code = 40, Description = "Popular donation" };
        public static FoodSource Other => new FoodSource { Code = 41, Description = "Other" };
    }

}
