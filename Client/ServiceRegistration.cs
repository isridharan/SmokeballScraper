using Microsoft.Extensions.DependencyInjection;

namespace Client
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddClientDependency(this IServiceCollection services)
        {
            services.AddScoped<IScraperClient, ScraperClient>();
            return services;
        }
    }
}
