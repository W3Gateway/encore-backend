namespace Encore.Domain.ValueObjects
{
    public class LocalizacaoDaMoradia : EsusIntegrationBase<LocalizacaoDaMoradia>
    {        
        public static LocalizacaoDaMoradia Urbana => new() { Code = 83, Description = "Urbana" };
        public static LocalizacaoDaMoradia Rural => new() { Code = 84, Description = "Rural" };
    }


}
