namespace Encore.Domain.ValueObjects
{
    public class TipoDeDomicilio : EsusIntegrationBase<TipoDeDomicilio>
    {
        public static TipoDeDomicilio House => new TipoDeDomicilio { Code = 85, Description = "Casa" };
        public static TipoDeDomicilio Apartment => new TipoDeDomicilio { Code = 86, Description = "Apartamento" };
        public static TipoDeDomicilio Room => new TipoDeDomicilio { Code = 87, Description = "Cômodo" };       
        public static TipoDeDomicilio Other => new TipoDeDomicilio { Code = 88, Description = "Outro" };
    }
}