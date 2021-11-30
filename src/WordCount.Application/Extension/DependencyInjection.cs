using WordCount.Application.Services.DataProcess;
using WordCount.Application.Services.Query;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtender
    {
        public static IServiceCollection AddAplicationDependacies(this IServiceCollection services)
        {
            services.AddTransient<IWordCounter, WordCounter>();
            services.AddScoped<ITextDataProcess, TextDataProcess>();
            services.AddScoped<IFileDataProcess, FileDataProcess>();
            services.AddScoped<IDataProcessFactory, DataProcessFactory>();
            services.AddScoped<IStatistics, Statistics>();
            services.AddInfrastructureDependacies();
            return services;
        }
    }
}
