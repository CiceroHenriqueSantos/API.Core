using API.CoreSystem.Manager.Application;
using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Repository.Contracts;
using API.CoreSystem.Manager.Repository.Repositories;
using API.CoreSystem.Manager.Services;
using API.CoreSystem.Manager.Services.Contracts;

namespace API.CoreSystem.Manager.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            AddServices(services);
            AddApplications(services);
            AddRepositories(services);
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
    }
}
