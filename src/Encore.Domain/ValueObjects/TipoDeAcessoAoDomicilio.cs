namespace Encore.Domain.ValueObjects
{
    public class TipoDeAcessoAoDomicilio : EsusIntegrationBase<TipoDeAcessoAoDomicilio>
    {
        public static TipoDeAcessoAoDomicilio Pavimento => new TipoDeAcessoAoDomicilio { Code = 89, Description = "Pavimento" };
        public static TipoDeAcessoAoDomicilio ChaoBatido => new TipoDeAcessoAoDomicilio { Code = 90, Description = "Chão batido" };
        public static TipoDeAcessoAoDomicilio Fluvial => new TipoDeAcessoAoDomicilio { Code = 91, Description = "Fluvial" };
        public static TipoDeAcessoAoDomicilio Other => new TipoDeAcessoAoDomicilio { Code = 92, Description = "Outro" };
    }
}