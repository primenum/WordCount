using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;
using WordCount.Infrastructure.Service;
using WordCount.Infrastructure.Service.Rest;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtender
    {
        public static IServiceCollection AddInfrastructureDependacies(this IServiceCollection services)
        {
            services.AddSingleton<IPersistanceInMemory, InMemory>();
            services.AddTransient<IPersistanceFactory, PersistanceFactory>();
            services.AddTransient<IPersistance, Persistance>();
            services.AddScoped<IRest, RestImplementation>();
            return services;
        }
    }
}
