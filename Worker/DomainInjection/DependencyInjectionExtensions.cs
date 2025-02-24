using Domain.DogFacts.Entity;
using Domain.DogFacts.Repository;
using Domain.DogFacts.Service;
using Infraestructure.Context;
using Infraestructure.Repository.DogFacts;
using Microsoft.EntityFrameworkCore;
using Worker.Jobs.ScheduleJobs;

namespace Worker.DomainInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureProducts(services);
            ConfigureJobs(services);
            return services;
        }

        public static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DogFactsContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static void ConfigureProducts(this IServiceCollection services)
        {
            services.AddScoped<IDogFactsRepository, DogFactsRepository>();
            services.AddScoped<IDogFactsService, DogFactsService>();
        }

        public static void ConfigureJobs(this IServiceCollection services)
        {
            services.AddTransient<IScheduleJobs, ScheduleJobs>();
        }
    }
}
