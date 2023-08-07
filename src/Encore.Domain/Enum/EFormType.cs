using System.ComponentModel;

namespace Encore.Domain.Enum
{
    public enum EFormType
    {
        [Description("visit")]
        Visit,
        [Description("home-home")]
        HomeHome,
        [Description("person-sociodemographic-information")]
        PersonSocioDemographicInformation,
        [Description("person-health-condition")]
        PersonHealthCondition,
    }
}
