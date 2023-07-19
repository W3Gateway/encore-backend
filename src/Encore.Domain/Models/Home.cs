using Encore.Domain.Core.Models;
using Encore.Domain.ValueObjects;

namespace Encore.Domain.Models
{
    public class Home : Entity<Home>
    {
        public string TypeProperty { get; private set; }
        public Adderess Adderess { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }
        public Guid ResponsiblePersonId { get; private set; }
        public Guid MicroregionId { get; private set; }

        public Person Person { get; set; }
        public Microregion Microregion { get; set; }


        public Home(Guid microregionId, Adderess adderess, string contactNumber, string? medicalRecordNumber, Guid responsiblePersonId, decimal householdIncome, int numberMembers)
        {
            TypeProperty = "Domiciliar";
            MicroregionId = microregionId;
            Adderess = adderess;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            ResponsiblePersonId = responsiblePersonId;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }
    }


}
