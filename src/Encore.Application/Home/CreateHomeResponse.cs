using Encore.Domain.Core.Responses;
using Encore.Domain.Models;
using Encore.Domain.ValueObjects;

namespace Encore.Application.Home
{
    public class CreateHomeResponse : Response<CreateHomeResponse> 
    {
        public string TypeProperty { get; set; }
        public Address Adderess { get; set; }
        public string ContactNumber { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
        public PersonResponse Responsible { get; set; }
        public MicroregionResponse Microregion { get; set; }

        public CreateHomeResponse(string typeProperty, Address adderess, string contactNumber, string? medicalRecordNumber, decimal householdIncome, int numberMembers, Person person, Microregion microregion)
        {
            TypeProperty = typeProperty;
            Adderess = adderess;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
            Responsible = new PersonResponse(person.Name, person.SocialName, person.Document, person.NationalHealthRegister, person.Email, person.ContactNumber);
            Microregion = new MicroregionResponse(microregion.Name);
        }
    }
}
