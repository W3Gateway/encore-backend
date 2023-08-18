namespace Encore.Application.Addresses
{
    public class AddressCommand
    {
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string StreetType { get; set; }
        public string? StreetComplement { get; set; }
        public string? Landmark { get; set; }
        public int Number { get; set; }
    }
}