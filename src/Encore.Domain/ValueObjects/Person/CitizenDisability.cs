namespace Encore.Domain.ValueObjects.Person
{
    public class CitizenDisability : EsusIntegrationBase<CitizenDisability>
    {
        public static CitizenDisability Hearing => new CitizenDisability { Code = 12, Description = "Auditiva" };
        public static CitizenDisability Visual => new CitizenDisability { Code = 13, Description = "Visual" };
        public static CitizenDisability IntellectualCognitive => new CitizenDisability { Code = 14, Description = "Intelectual/Cognitiva" };
        public static CitizenDisability Physical => new CitizenDisability { Code = 15, Description = "Física" };
        public static CitizenDisability Other => new CitizenDisability { Code = 16, Description = "Outra" };
    }
}
