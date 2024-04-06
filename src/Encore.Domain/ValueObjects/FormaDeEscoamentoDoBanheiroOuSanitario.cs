namespace Encore.Domain.ValueObjects
{
    public class FormaDeEscoamentoDoBanheiroOuSanitario : EsusIntegrationBase<FormaDeEscoamentoDoBanheiroOuSanitario>
    {
        public static FormaDeEscoamentoDoBanheiroOuSanitario RedeColetoraEsgotoPluvial => new() { Code = 122, Description = "Rede coletora de esgoto ou pluvial" };
        public static FormaDeEscoamentoDoBanheiroOuSanitario FossaSeptica => new() { Code = 123, Description = "Fossa séptica" };
        public static FormaDeEscoamentoDoBanheiroOuSanitario FossaRudimentar => new() { Code = 124, Description = "Fossa rudimentar" };
        public static FormaDeEscoamentoDoBanheiroOuSanitario DiretoRioLagoMar => new() { Code = 125, Description = "Direto para um rio, lago ou mar" };
        public static FormaDeEscoamentoDoBanheiroOuSanitario CeuAberto => new() { Code = 126, Description = "Céu aberto" };
        public static FormaDeEscoamentoDoBanheiroOuSanitario OutraForma => new() { Code = 127, Description = "Outra forma" };
    }
}