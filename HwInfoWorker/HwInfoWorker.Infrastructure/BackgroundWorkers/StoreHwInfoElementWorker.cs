using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using HwInfoWorker.Domain.SeedWork;
using HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements;
using HwInfoWorker.Shared.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HwInfoWorker.Infrastructure.BackgroundWorkers
{
    public class StoreHwInfoElementWorker : BackgroundService, IBackgroundWorker
    {
        private readonly ILogger<StoreHwInfoElementWorker> _logger;
        private readonly IHwInfoElementsStore _store;
        private readonly IHwInfoElementRepository _repository;
        private readonly IConfiguration _configuration;

        public StoreHwInfoElementWorker(ILogger<StoreHwInfoElementWorker> logger, IHwInfoElementsStore store, IHwInfoElementRepository repository, IConfiguration configuration)
        {
            _logger = logger;
            _store = store;
            _repository = repository;
            _configuration = configuration;
        }

        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            _logger.LogInformation("Worker is started at: {UtcNow}", DateTime.UtcNow);
        }

        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            _logger.LogInformation("Worker is stopped at: {UtcNow}", DateTime.UtcNow);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var delayMs = _configuration.GetValue<int>("BackgroundWorkers:StoreHwInfoElementWorker:DelayMs");

            while (!cancellationToken.IsCancellationRequested)
            {
                var sensors = _repository.GetSensors();
                var readings = _repository.GetReadings();

                var hwInfoElement = HwInfoElement.Create(sensors, readings);

                using (_logger.BeginScope(LoggingScope.Create().Add("HwInfoElementId", hwInfoElement.Id)))
                {
                    if(await _store.TryStore(hwInfoElement, cancellationToken))
                    {
                        _logger.LogInformation("Worker successfully stored an hwInfoElement at: {UtcNow}", DateTime.UtcNow);
                    }
                }
                
                await Task.Delay(delayMs, cancellationToken);
            }
        }
    }
}
