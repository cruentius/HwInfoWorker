using HwInfoReader.AspNetCore;
using HwInfoWorker.Infrastructure;
using HwInfoWorker.Infrastructure.BackgroundWorkers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.AddEventLog(settings =>
                    {
                        settings.LogName = "HwInfoWorker";
                        settings.SourceName = "HwInfoWorker";
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var environment = hostContext.HostingEnvironment;

                    services.AddHwInfoReader();
                    services.AddInfrastructure(configuration, environment);

                    services.AddHostedService<StoreHwInfoElementWorker>();
                });
    }
}
