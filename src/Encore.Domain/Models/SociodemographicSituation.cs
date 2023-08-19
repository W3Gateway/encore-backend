using Encore.Domain.Core.Models;
using FluentValidation;

namespace Encore.Domain.Models
{
    public class SociodemographicSituation : Entity<SociodemographicSituation>
    {
        public bool AttendSchool { get; set; }
        public string LevelEducation { get; set; }
        public string? LaborMarketSituation { get; set; }
        public string? Occupation { get; set; }
        public bool? HasTraditionalCaregiver { get; set; }
        public bool? IsMemberCommunityGroup { get; set; }
        public bool? HasPrivateHealthPlan { get; set; }
        public bool? IsMemberTraditionalCommunity { get; set; }
        public string? TraditionalCommunity { get; set; }
        public bool HasSexualOrientation { get; set; }
        public string SexualOrientation { get; set; }
        public bool HasGenderIdentity { get; set; }
        public string GenderIdentity { get; set; }
        public bool HasDisability { get; set; }
        public string? Disability { get; set; }

        #region Mapping 
        public IEnumerable<Person> Persons { get; set; }
        #endregion


        public override async Task<bool> IsValidAsync()
        {
            RuleFor(c => c.AttendSchool).NotEmpty();

            ValidationResult = await ValidateAsync(this);
            return ValidationResult.IsValid;
        }

        public void CopyProperties(SociodemographicSituation sociodemographic)
        {
            AttendSchool = sociodemographic.AttendSchool;
            LevelEducation = sociodemographic.LevelEducation;
            LaborMarketSituation = sociodemographic.LaborMarketSituation;
            Occupation = sociodemographic.Occupation;
            HasTraditionalCaregiver = sociodemographic.HasTraditionalCaregiver;
            IsMemberCommunityGroup = sociodemographic.IsMemberCommunityGroup;
            HasPrivateHealthPlan = sociodemographic.HasPrivateHealthPlan;
            IsMemberTraditionalCommunity = sociodemographic.IsMemberTraditionalCommunity;
            TraditionalCommunity = sociodemographic.TraditionalCommunity;
            HasSexualOrientation = sociodemographic.HasSexualOrientation;
            SexualOrientation = sociodemographic.SexualOrientation;
            HasGenderIdentity = sociodemographic.HasGenderIdentity;
            GenderIdentity = sociodemographic.GenderIdentity;
            HasDisability = sociodemographic.HasDisability;
            Disability = sociodemographic.Disability;
        }
    }
}
