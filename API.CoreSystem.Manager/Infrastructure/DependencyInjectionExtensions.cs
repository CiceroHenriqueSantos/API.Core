using API.CoreSystem.Manager.Application;
using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Repository.Contracts;
using API.CoreSystem.Manager.Repository.Repositories;
using API.CoreSystem.Manager.Services;
using API.CoreSystem.Manager.Services.Contracts;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace API.CoreSystem.Manager.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static string PolicyName => "Core_Cors";

        public static void AddDIServices(this IServiceCollection services)
        {
            AddServices(services);
            AddApplications(services);
            AddRepositories(services);
            AddCoreCors(services);
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
        }

        private static void AddApplications(this IServiceCollection services)
        {
            services.AddTransient<IPersonApp, PersonApp>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPersonRepository, PersonRepository>();
        }

        public static IApplicationBuilder UseCoreCors(this IApplicationBuilder app)
        {
            return app.UseCors(PolicyName);
        }

        private static IServiceCollection AddCoreCors(this IServiceCollection services)
        {
            return services.AddCors(delegate (CorsOptions options)
            {
                options.AddPolicy(PolicyName, delegate (CorsPolicyBuilder p)
                {
                    p.AllowAnyOrigin();
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                });
            });
        }
    }
}
