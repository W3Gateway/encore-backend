using Encore.Domain.Core.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Encore.Presenter.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static void AddAuthenticationJwt(this IServiceCollection services)
            => services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddBearer();

        public static AuthenticationBuilder AddBearer(this AuthenticationBuilder builder)
        {
            builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtOptions>();
            builder.AddJwtBearer();
            return builder;
        }
    }

    public class ConfigureJwtOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtAppOptions _options;

        public ConfigureJwtOptions(IOptions<JwtAppOptions> options)
        {
            _options = options.Value;
        }

        public void Configure(string name, JwtBearerOptions options)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            options.Audience = _options.Audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateLifetime = true,
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(Options.DefaultName, options);
        }
    }
}
