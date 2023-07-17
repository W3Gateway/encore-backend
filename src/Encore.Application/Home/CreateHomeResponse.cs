using Encore.Domain.Core.Responses;
using Encore.Domain.Models;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Home
{
    public class CreateHomeResponse : Response<CreateHomeResponse> 
    {
        public string TypeProperty { get; set; }
        public Adderess Adderess { get; set; }
        public string ContactNumber { get; set; }
        public long? FamilyRecord { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
        public PersonResponse Responsible { get; set; }
        public MicroregionResponse Microregion { get; set; }

        public CreateHomeResponse(string typeProperty, Adderess adderess, string contactNumber, long? familyRecord, decimal householdIncome, int numberMembers, Person person, Microregion microregion)
        {
            TypeProperty = typeProperty;
            Adderess = adderess;
            ContactNumber = contactNumber;
            FamilyRecord = familyRecord;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
            Responsible = new PersonResponse(person.Name, person.SocialName, person.Document, person.NationalHealthRegister, person.Email, person.ContactNumber);
            Microregion = new MicroregionResponse(microregion.Name);
        }
    }
}
