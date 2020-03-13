using HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.Configuration;
using HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements;
using HwInfoWorker.Shared.Extensions;
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
            configuration.Bind<ElasticSearchStoreConfiguration>(ElasticSearchStoreConstants.Name, out var config);

            services
                .Configure<ElasticSearchStoreConfiguration>(configuration.GetSection(ElasticSearchStoreConstants.Name))
                .AddSingleton<IElasticClient>(new ElasticClient(ConnectionSettings(config.EndpointAddress, config.IndexName)))
                .AddTransient<IHwInfoElementsStore, HwInfoElementsStore>();

            return services;
        }

        private static ConnectionSettings ConnectionSettings(string endpointAddress, string defaultIndex) =>
            new ConnectionSettings(new Uri(endpointAddress))
                .DefaultIndex(defaultIndex);
    }
}
