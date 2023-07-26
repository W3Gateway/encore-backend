namespace Encore.Domain.Core.Options
{
    public class JwtAppOptions
    {
        public string SecretKey { get; set; }
        public string ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
