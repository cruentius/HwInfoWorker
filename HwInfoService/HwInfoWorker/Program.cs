using HwInfoReader.AspNetCore;
using HwInfoWorker.Infrastructure;
using HwInfoWorker.Infrastructure.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HwInfoWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var environment = hostContext.HostingEnvironment;

                    services.AddHwInfoReader();
                    services.AddInfrastructure(configuration, environment);
                    services.AddHostedService<StoreHwInfoElementService>();
                });
    }
}
