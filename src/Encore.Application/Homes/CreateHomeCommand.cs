using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Homes
{
    public class CreateHomeCommand : Command<Response<CreateHomeResponse>>
    {
        public Guid MicroregionId { get; private set; }
        public Address Adderess { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public string ResponsiblePersonDocument { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }

        public CreateHomeCommand(Guid microregionId, Address adderess, string contactNumber, string? medicalRecordNumber, string responsiblePersonDocument, decimal householdIncome, int numberMembers)
        {
            MicroregionId = microregionId;
            Adderess = adderess;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            ResponsiblePersonDocument = responsiblePersonDocument;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }
    }
}
