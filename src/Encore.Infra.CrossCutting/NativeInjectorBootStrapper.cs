using Encore.Domain.Core.Data;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Infra.CrossCutting.Mapper;
using Encore.Infra.CrossCutting.Services;
using Encore.Infra.Data.Context;
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
            var mappers = AutoMapperConfig.Setup();
            var temp = new List<Type>(mappers);
            services.AddAutoMapper(temp.ToArray());
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
            services.AddScoped<IMicroregionRepository, MicroregionRepository>();
            services.AddScoped<IHealthCenterRepository, HealhCenterRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IUnitOfWork, ApplicationContext>();
        }
    }
}