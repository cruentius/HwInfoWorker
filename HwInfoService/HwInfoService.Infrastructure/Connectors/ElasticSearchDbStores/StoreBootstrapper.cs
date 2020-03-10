using DearNova.ApplicationConfiguration;
using HwInfoService.Infrastructure.Connectors.ElasticSearchDbStores.Configuration;
using HwInfoService.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace HwInfoService.Infrastructure.Connectors.ElasticSearchDbStores
{
    public static class ElasticSearchConstants
    {
        public const string Name = "ElasticSearchService";
    }

    public static class StoreBootstrapper
    {
        public static IServiceCollection AddStores(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(ElasticSearchConstants.Name)
                .Get<ElasticSearchConfiguration>();

            services
                .AddSingletonConfiguration<ElasticSearchConfiguration>(configuration)
                .AddSingleton<IElasticClient>(new ElasticClient(ConnectionSettings(config.EndpointAddress, config.IndexName)))
                .AddTransient<IHwInfoElementsStore, HwInfoElementsStore>();

            return services;
        }

        private static ConnectionSettings ConnectionSettings(string endpointAddress, string defaultIndex) =>
            new ConnectionSettings(new Uri(endpointAddress))
                .DefaultIndex(defaultIndex);
    }
}
