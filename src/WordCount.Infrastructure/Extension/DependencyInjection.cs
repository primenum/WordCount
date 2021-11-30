using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtender
    {
        public static IServiceCollection AddInfrastructureDependacies(this IServiceCollection services)
        {
            services.AddTransient<IPersistanceFactory, PersistanceFactory>();
            services.AddSingleton<IPersistanceInMemory, InMemory>();
            return services;
        }
    }
}
