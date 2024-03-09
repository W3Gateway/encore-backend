namespace Encore.Domain.ValueObjects
{
    public class HomeCareOrigin : EsusIntegrationBase<HomeCareOrigin>
    {
        public static HomeCareOrigin BasicCare => new HomeCareOrigin { Code = 1, Description = "Atenção Básica" };
        public static HomeCareOrigin Hospitalization => new HomeCareOrigin { Code = 11, Description = "Internação hospitalar" };
        public static HomeCareOrigin UrgentEmergency => new HomeCareOrigin { Code = 12, Description = "Urgência e emergência" };
        public static HomeCareOrigin CACON_UNACON => new HomeCareOrigin { Code = 13, Description = "CACON / UNACON" };
        public static HomeCareOrigin PatientInitiative => new HomeCareOrigin { Code = 16, Description = "Iniciativa do paciente ou terceiros" };
        public static HomeCareOrigin Others => new HomeCareOrigin { Code = 6, Description = "Outros" };
    }
}
