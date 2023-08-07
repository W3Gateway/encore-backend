using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Homes.Commands
{
    public class HomeUpdateCommand : Command<Response<HomeResponse>>
    {
        public Guid Id { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public string? HeadFamilyDocument { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }
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
