using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Infra.CrossCutting.Services;
using Encore.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Encore.Infra.CrossCutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterData(services);
            RegisterServicesLayers(services);
        }

        private static void RegisterServicesLayers(IServiceCollection services)
        {
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IEntityToDtoMapper<,>), typeof(EntityToDtoMapper<,>));
        }

        private static void RegisterData(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuestionAnswerRepository, QuestionAnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IChecklistQuestionRepository, ChecklistQuestionRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
        }
    }
}