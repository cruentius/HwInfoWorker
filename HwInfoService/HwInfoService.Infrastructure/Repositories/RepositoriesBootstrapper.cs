using HwInfoService.Domain.AggregatesModel.HwInfoElementAggregate;
using HwInfoService.Infrastructure.Repositories.HwInfo;
using Microsoft.Extensions.DependencyInjection;

namespace HwInfoService.Infrastructure.Repositories
{
    public static class RepositoriesBootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IHwInfoRepository, HwInfoRepository>();

            return services;
        }
    }
}
