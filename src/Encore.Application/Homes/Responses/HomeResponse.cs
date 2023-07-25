using Encore.Application.Microregions;
using Encore.Application.Persons.Responses;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Homes.Responses
{
    public class HomeResponse
    {
        public string TypeProperty { get; set; }
        public Address Adderess { get; set; }
        public string ContactNumber { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
        public PersonHomeResponse HeadFamily { get; set; }
        public MicroregionResponse Microregion { get; set; }
    }
}
