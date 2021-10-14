using Domain.Query;
using Domain.Query.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddHandlerDependency(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<SearchMatchQuery, SearchMatchResponse>, SearchMatchQueryHandler>();
            return services;
        }
    }
}
