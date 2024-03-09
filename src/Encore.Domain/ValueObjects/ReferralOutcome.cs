namespace Encore.Domain.ValueObjects
{
    public class ReferralOutcome : EsusIntegrationBase<ReferralOutcome>
    {
        public static ReferralOutcome Stay => new ReferralOutcome { Code = 7, Description = "Permanência" };
        public static ReferralOutcome AdministrativeDischarge => new ReferralOutcome { Code = 3, Description = "Alta administrativa" };
        public static ReferralOutcome ClinicalDischarge => new ReferralOutcome { Code = 1, Description = "Alta clínica" };
        public static ReferralOutcome Death => new ReferralOutcome { Code = 9, Description = "Óbito" };
        public static ReferralOutcome BasicCare => new ReferralOutcome { Code = 2, Description = "Atenção Básica (AD1)" };
        public static ReferralOutcome UrgentEmergencyService => new ReferralOutcome { Code = 4, Description = "Serviço de urgência e emergência" };
        public static ReferralOutcome HospitalInpatientService => new ReferralOutcome { Code = 5, Description = "Serviço de internação hospitalar" };
    }


}
