using Encore.Domain.Core.Models;
using Encore.Domain.ValueObjects;

namespace Encore.Domain.Models
{
    public class Home : Entity<Home>
    {
        public string TypeProperty { get; private set; }
        public Address Address { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }
        public Guid ResponsiblePersonId { get; private set; }
        public Guid MicroregionId { get; private set; }

        #region Mapping
        public Person Person { get; set; }
        public Microregion Microregion { get; set; }
        public List<Visit> Visits { get; set; }
        #endregion

        public Home(Guid microregionId, /*Address address,*/ string contactNumber, string? medicalRecordNumber, Guid responsiblePersonId, decimal householdIncome, int numberMembers)
        {
            TypeProperty = "Domiciliar";
            MicroregionId = microregionId;
            //Address = address;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            ResponsiblePersonId = responsiblePersonId;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }
    }


}
