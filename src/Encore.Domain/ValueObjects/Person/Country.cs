namespace Encore.Domain.ValueObjects.Person
{
    public class Country : EsusIntegrationBase<Country>
    {
        public string CountryName { get; set; }

        
        public static Country Brazil => new Country { Code = 31, CountryName = "BRASIL" };

    }
}
