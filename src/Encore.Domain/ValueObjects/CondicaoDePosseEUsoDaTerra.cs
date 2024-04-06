namespace Encore.Domain.ValueObjects
{
    public class CondicaoDePosseEUsoDaTerra : EsusIntegrationBase<CondicaoDePosseEUsoDaTerra>
    {
        public static CondicaoDePosseEUsoDaTerra Collected => new() { Code = 93, Description = "Coletado" };
        public static CondicaoDePosseEUsoDaTerra Burned => new() { Code = 94, Description = "Queimado/Enterrado" };
        public static CondicaoDePosseEUsoDaTerra ClearSky => new() { Code = 95, Description = "Céu aberto" };
        public static CondicaoDePosseEUsoDaTerra Other => new() { Code = 96, Description = "Outro" };
    }
}