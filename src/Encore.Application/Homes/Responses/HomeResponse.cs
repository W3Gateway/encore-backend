using Encore.Domain.ValueObjects;

namespace Encore.Application.Homes.Responses
{
    public class HomeResponse
    {
        public Guid Id { get; set; }
        public string? TypeProperty { get; set; }
        public Address? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
        public string? ResponsibleDocument { get; set; }
        public HomeMicroregionResponse? Microregion { get; set; }
    }
}
