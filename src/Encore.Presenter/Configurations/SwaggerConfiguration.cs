using Encore.Domain.Core.Attributes;
using Encore.Domain.Core.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Encore.Presenter.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Encore API", Version = "v1" });
                c.OperationFilter<SwaggerExcludePropertyFilter>();
                c.SchemaFilter<SwaggerExcludeFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }
    }

    public class SwaggerExcludePropertyFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation?.Parameters == null || !operation.Parameters.Any())
                return;

            var parametersWithPropertiesToIgnore = context.ApiDescription
                .ActionDescriptor.Parameters.Where(p =>
                    p.ParameterType.GetProperties()
                        .Any(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null));

            foreach (var parameter in parametersWithPropertiesToIgnore)
            {
                var ignoreDataMemberProperties = parameter.ParameterType.GetProperties()
                    .Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null)
                    .Select(p => p.Name.ToLower());

                operation.Parameters = operation.Parameters.Where(p => !ignoreDataMemberProperties.Any(idmp => p.Name.ToLower().Contains(idmp))).ToList();
            }
        }
    }

    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties is null)
                return;

            var excludedProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
            if (!excludedProperties.Any())
                return;

            foreach (var excludedProperty in excludedProperties)
            {
                var key = excludedProperty.Name.ToCamelCase();
                if (schema.Properties.ContainsKey(key))
                    schema.Properties.Remove(key);
            }
        }
    }
}