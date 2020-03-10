using DearNova.ApplicationConfiguration;
using HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.Configuration;
using HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores
{
    public static class ElasticSearchStoreConstants
    {
        public const string Name = "ElasticSearchStore";
    }

    public static class StoreBootstrapper
    {
        public static IServiceCollection AddStores(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(ElasticSearchStoreConstants.Name)
                .Get<ElasticSearchStoreConfiguration>();

            services
                .AddSingletonConfiguration<ElasticSearchStoreConfiguration>(configuration)
                .AddSingleton<IElasticClient>(new ElasticClient(ConnectionSettings(config.EndpointAddress, config.IndexName)))
                .AddTransient<IHwInfoElementsStore, HwInfoElementsStore>();

            return services;
        }

        private static ConnectionSettings ConnectionSettings(string endpointAddress, string defaultIndex) =>
            new ConnectionSettings(new Uri(endpointAddress))
                .DefaultIndex(defaultIndex);
    }
}
