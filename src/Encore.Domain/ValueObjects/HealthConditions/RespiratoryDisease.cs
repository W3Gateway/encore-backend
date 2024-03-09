namespace Encore.Domain.ValueObjects.HealthConditions
{
    public class RespiratoryDisease : EsusIntegrationBase<RespiratoryDisease>
    {
        public static RespiratoryDisease Asthma => new RespiratoryDisease { Code = 30, Description = "Asma" };
        public static RespiratoryDisease COPDEmphysema => new RespiratoryDisease { Code = 31, Description = "DPOC / Enfisema" };
        public static RespiratoryDisease Other => new RespiratoryDisease { Code = 32, Description = "Outro" };
        public static RespiratoryDisease Unknown => new RespiratoryDisease { Code = 33, Description = "Não sabe" };
    }
}
