using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Homes.Commands
{
    public class HomeUpdateCommand : Command<Response<HomeResponse>>
    {
        public Guid Id { get; private set; }
        public Guid MicroregionId { get; private set; }
        public Address Adderess { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public string HeadFamilyDocument { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }

        public HomeUpdateCommand(Guid id, Guid microregionId, Address adderess, string contactNumber, string? medicalRecordNumber, string headFamilyDocument, decimal householdIncome, int numberMembers)
        {
            Id = id;
            MicroregionId = microregionId;
            Adderess = adderess;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            HeadFamilyDocument = headFamilyDocument;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }
    }
}
