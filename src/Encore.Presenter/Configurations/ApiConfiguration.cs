using Encore.Domain.Core.Options;

namespace Encore.Presenter.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAppOptions>(configuration.GetSection("JwtApp"));
        }
    }
}