namespace Encore.Domain.ValueObjects
{
    public class VaccinationStrategy : EsusIntegrationBase<VaccinationStrategy>
    {
        public long RNDSCode { get; set; }

        public static VaccinationStrategy Routine => new VaccinationStrategy { Code = 1, Description = "Routine", RNDSCode = 1 };
        public static VaccinationStrategy Special => new VaccinationStrategy { Code = 2, Description = "Special", RNDSCode = 2 };
        public static VaccinationStrategy Blockage => new VaccinationStrategy { Code = 3, Description = "Blockage", RNDSCode = 3 };
        public static VaccinationStrategy Intensification => new VaccinationStrategy { Code = 4, Description = "Intensification", RNDSCode = 4 };
        public static VaccinationStrategy IndiscriminateCampaign => new VaccinationStrategy { Code = 5, Description = "Indiscriminate campaign", RNDSCode = 5 };
        public static VaccinationStrategy SelectiveCampaign => new VaccinationStrategy { Code = 6, Description = "Selective campaign", RNDSCode = 6 };
        public static VaccinationStrategy SerumTherapy => new VaccinationStrategy { Code = 7, Description = "Serum therapy", RNDSCode = 7 };
        public static VaccinationStrategy Research => new VaccinationStrategy { Code = 11, Description = "Research", RNDSCode = 10 };
    }
}
