using Microsoft.Extensions.DependencyInjection;
using StrategyExample.Services.Strategies;

namespace StrategyExample.Services
{
    public static class ServiceCollectionRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IExampleService, ExampleService>();
            serviceCollection.AddSortStrategies();

            return serviceCollection;
        }

        private static void AddSortStrategies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IExampleSortStrategy, NameSortAscStrategy>();
            serviceCollection.AddScoped<IExampleSortStrategy, NameSortDescStrategy>();
            serviceCollection.AddScoped<IExampleSortStrategy, AgeSortAscStrategy>();
            serviceCollection.AddScoped<IExampleSortStrategy, AgeSortDescStrategy>();
        }
    }
}