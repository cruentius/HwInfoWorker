using HwInfoService.Infrastructure.Connectors.ElasticSearchDbStores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HwInfoService.Infrastructure.Connectors
{
    public static class ConnectorsBootstrapper
    {
        public static IServiceCollection AddConnectors(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddStores(configuration);

            return services;
        }
    }
}
