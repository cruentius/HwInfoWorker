using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using HwInfoWorker.Infrastructure.Repositories.HwInfo;
using Microsoft.Extensions.DependencyInjection;

namespace HwInfoWorker.Infrastructure.Repositories
{
    public static class RepositoriesBootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IHwInfoElementRepository, HwInfoElementRepository>();

            return services;
        }
    }
}
