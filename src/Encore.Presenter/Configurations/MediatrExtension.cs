using Encore.Application;

namespace Encore.Presenter.Configurations
{
    public static class MediatrExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Ping>());
        }
    }
}