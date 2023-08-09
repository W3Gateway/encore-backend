using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class HealthCondition : Entity<HealthCondition>
    {
        public string WeightCondition { get; set; }
        public bool IsSmoker { get; set; }
        public bool UseAlcohol { get; set; }
        public bool UsesOtherDrugs { get; set; }
        public bool HasHypertension { get; set; }
        public bool HasDiabetes { get; set; }
        public bool HadStroke { get; set; }
        public bool HadHeartAttack { get; set; }
        public bool HasHeartDisease { get; set; }
        public string HeartDisease { get; set; }
        public bool HasRespiratoryDisease { get; set; }
        public string RespiratoryDisease { get; set; }
        public bool HasLeprosy { get; set; }
        public bool HadCanser { get; set; }
        public bool ReacentlyHospitalization { get; set; }
        public string CauseHospotalization { get; set; }
        public bool DiagnoseMentalHealthProblem { get; set; }
        public bool IsBedridden { get; set; }
        public bool IsDomiciled { get; set; }
        public bool UseMedicinalPlants { get; set; }
        public string MedicinalPlants { get; set; }
        public string OtherHealthConditions { get; set; }
        public bool StreetSituation { get; set; }
        public Guid PersonId { get; set; }

        #region Mapping 
        public Person Person { get; set; }
        #endregion

        public void AddPerson(Guid personId) => PersonId = personId;

    }
}
