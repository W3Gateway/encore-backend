namespace Encore.Domain.ValueObjects
{
    public class DentalReferralProcedure : EsusIntegrationBase<DentalReferralProcedure>
    {
        public static DentalReferralProcedure ScheduledReturnConsultation => new DentalReferralProcedure { Code = 16, Description = "Retorno para consulta agendada" };
        public static DentalReferralProcedure ScheduledForOtherABProfessionals => new DentalReferralProcedure { Code = 12, Description = "Agendamento para outros profissionais AB" };
        public static DentalReferralProcedure ScheduledForNASF => new DentalReferralProcedure { Code = 13, Description = "Agendamento para NASF" };
        public static DentalReferralProcedure ScheduledForGroups => new DentalReferralProcedure { Code = 14, Description = "Agendamento para grupos" };
        public static DentalReferralProcedure TreatmentCompleted => new DentalReferralProcedure { Code = 15, Description = "Tratamento concluído" };
        public static DentalReferralProcedure EpisodeDischarge => new DentalReferralProcedure { Code = 17, Description = "Alta do episódio" };
        public static DentalReferralProcedure SpecialNeedsPatientsCare => new DentalReferralProcedure { Code = 1, Description = "Atendimento à pacientes com necessidades especiais" };
        public static DentalReferralProcedure BMFSurgery => new DentalReferralProcedure { Code = 2, Description = "Cirurgia BMF" };
        public static DentalReferralProcedure Endodontics => new DentalReferralProcedure { Code = 3, Description = "Endodontia" };
        public static DentalReferralProcedure Stomatology => new DentalReferralProcedure { Code = 4, Description = "Estomatologia" };
        public static DentalReferralProcedure Implantology => new DentalReferralProcedure { Code = 5, Description = "Implantodontia" };
        public static DentalReferralProcedure PediatricDentistry => new DentalReferralProcedure { Code = 6, Description = "Odontopediatria" };
        public static DentalReferralProcedure Orthodontics => new DentalReferralProcedure { Code = 7, Description = "Ortodontia/Ortopedia" };
        public static DentalReferralProcedure Periodontics => new DentalReferralProcedure { Code = 8, Description = "Periodontia" };
        public static DentalReferralProcedure DentalProsthesis => new DentalReferralProcedure { Code = 9, Description = "Prótese dentária" };
        public static DentalReferralProcedure Radiology => new DentalReferralProcedure { Code = 10, Description = "Radiologia" };
        public static DentalReferralProcedure Other => new DentalReferralProcedure { Code = 11, Description = "Outros" };
    }


}
