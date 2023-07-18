namespace Encore.Domain.ValueObjects
{
    public class Adderess
    {
        public int PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string? StreetComplement { get; set; }
        public string? Landmark { get; set; }
        public string Number { get; set; }
    }
}