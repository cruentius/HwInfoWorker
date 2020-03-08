using HwInfoService.Infrastructure.Connectors;
using HwInfoService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HwInfoService.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services
                .AddConnectors(configuration)
                .AddRepositories();

            return services;
        }
    }
}
