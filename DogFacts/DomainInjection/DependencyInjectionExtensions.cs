using Domain.DogFacts.Entity;
using Domain.DogFacts.Repository;
using Domain.DogFacts.Service;
using Infraestructure.Context;
using Infraestructure.Repository.DogFacts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DogFacts.DomainInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration) 
        {
            ConfigureContext(services, configuration);
            ConfigureProducts(services);
            return services;
        }

        public static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DogFactsContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Default"))
            .UseSeeding((context, _) => 
            {

                var testBlog = context.Set<DogFactsEntity>().FirstOrDefault();
                if (testBlog == null)
                {
                    context.Set<DogFactsEntity>().Add(new DogFactsEntity(Guid.Parse("c7e8ab41-b156-498f-b49e-be62f919c39c"), "bad", "Stronger", DateTime.UtcNow));
                    context.SaveChanges();
                }
            }));
        }

        public static void ConfigureProducts(this IServiceCollection services)
        {
            services.AddScoped<IDogFactsRepository, DogFactsRepository>();
            services.AddScoped<IDogFactsService, DogFactsService>();
        }
    }
}
