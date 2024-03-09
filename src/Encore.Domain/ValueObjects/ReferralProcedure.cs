namespace Encore.Domain.ValueObjects
{
    public class ReferralProcedure : EsusIntegrationBase<ReferralProcedure>
    {
        public static ReferralProcedure ScheduledReturnConsultation => new ReferralProcedure { Code = 1, Description = "Retorno para consulta agendada" };
        public static ReferralProcedure ScheduledContinuedCare => new ReferralProcedure { Code = 2, Description = "Retorno para cuidado continuado / programado" };
        public static ReferralProcedure GroupAppointment => new ReferralProcedure { Code = 12, Description = "Agendamento para grupos" };
        public static ReferralProcedure AppointmentForNASF => new ReferralProcedure { Code = 3, Description = "Agendamento para NASF" };
        public static ReferralProcedure EpisodeDischarge => new ReferralProcedure { Code = 9, Description = "Alta do episódio" };
        public static ReferralProcedure InternalReferral => new ReferralProcedure { Code = 11, Description = "Encaminhamento interno no dia" };
        public static ReferralProcedure SpecializedServiceReferral => new ReferralProcedure { Code = 4, Description = "Encaminhamento para serviço especializado" };
        public static ReferralProcedure CAPSReferral => new ReferralProcedure { Code = 5, Description = "Encaminhamento para CAPS" };
        public static ReferralProcedure HospitalizationReferral => new ReferralProcedure { Code = 6, Description = "Encaminhamento para internação hospitalar" };
        public static ReferralProcedure UrgencyReferral => new ReferralProcedure { Code = 7, Description = "Encaminhamento para urgência" };
        public static ReferralProcedure HomeCareServiceReferral => new ReferralProcedure { Code = 8, Description = "Encaminhamento para serviço de atenção domiciliar" };
        public static ReferralProcedure IntersectoralReferral => new ReferralProcedure { Code = 10, Description = "Encaminhamento intersetorial" };
    }


}
