using Encore.Domain.ValueObjects;

namespace Encore.Application.Persons.Responses
{
    public class PersonHomeResponse
    {
        public string TypeProperty { get; set; }
        public Address Address { get; set; }
        public string ContactNumber { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
    }
}
