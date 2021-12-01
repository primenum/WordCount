using WordCount.Application.Services.Data;
using WordCount.Application.Services.Data.Implementation;
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
            services.AddScoped<IWebResourceDataProcess, WebResourceDataProcess>();
            services.AddScoped<IDataProcessFactory, DataProcessFactory>();
            services.AddScoped<IStatistics, Statistics>();
            services.AddScoped<IDataAnalize, DataAnalize>();

            
            services.AddInfrastructureDependacies();
            return services;
        }
    }
}
