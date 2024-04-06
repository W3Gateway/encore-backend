namespace Encore.Domain.ValueObjects
{
    public class TipoDeDomicilio : EsusIntegrationBase<TipoDeDomicilio>
    {
        public static TipoDeDomicilio House => new TipoDeDomicilio { Code = 93, Description = "Casa" };
        public static TipoDeDomicilio Apartment => new TipoDeDomicilio { Code = 94, Description = "Apartamento" };
        public static TipoDeDomicilio Room => new TipoDeDomicilio { Code = 95, Description = "Cômodo" };       
        public static TipoDeDomicilio Other => new TipoDeDomicilio { Code = 96, Description = "Outro" };
    }
}