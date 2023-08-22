using Encore.Domain.Core.Messaging;

namespace Encore.Application.SociodemographicSituations
{
    public class SociodemographicSituationCommand : Command
    {
        public Guid Id { get; set; }
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
    }
}