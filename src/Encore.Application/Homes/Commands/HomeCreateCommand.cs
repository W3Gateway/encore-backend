using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Homes.Commands
{
    public class HomeCreateCommand : Command<Response<HomeResponse>>
    {
        public Guid MicroregionId { get; private set; }
        public Address Adderess { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }

        public HomeCreateCommand(Guid microregionId, Address adderess, string contactNumber, string? medicalRecordNumber, decimal householdIncome, int numberMembers)
        {
            MicroregionId = microregionId;
            Adderess = adderess;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }
    }
}
