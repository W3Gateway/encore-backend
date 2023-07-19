using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Home
{
    public class CreateHomeCommand : Command<Response<CreateHomeResponse>>
    {
        public Guid MicroregionId { get; set; }
        public Address Adderess { get; set; }
        public string ContactNumber { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public string ResponsibleDocument { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
    }
}
