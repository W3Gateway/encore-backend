using Encore.Infra.Data.Context;

namespace Encore.Presenter.Configurations
{
    public static class DataConfiguration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
        }
    }
}