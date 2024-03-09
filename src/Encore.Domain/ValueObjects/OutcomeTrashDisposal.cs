namespace Encore.Domain.ValueObjects
{
    public class OutcomeTrashDisposal : EsusIntegrationBase<OutcomeTrashDisposal>
    {
        public static OutcomeTrashDisposal Collected => new OutcomeTrashDisposal { Code = 93, Description = "Coletado" };
        public static OutcomeTrashDisposal BurnedBuried => new OutcomeTrashDisposal { Code = 94, Description = "Queimado / Enterrado" };
        public static OutcomeTrashDisposal OpenSky => new OutcomeTrashDisposal { Code = 95, Description = "Céu aberto" };
        public static OutcomeTrashDisposal Other => new OutcomeTrashDisposal { Code = 96, Description = "Outro" };
    }
}
