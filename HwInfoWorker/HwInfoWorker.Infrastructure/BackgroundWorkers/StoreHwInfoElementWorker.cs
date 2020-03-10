using HwInfoWorker.Domain.AggregatesModel.HwInfoElementAggregate;
using HwInfoWorker.Domain.SeedWork;
using HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements;
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

            _logger.LogInformation($"Worker is started at {DateTime.Now}");
        }

        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            _logger.LogInformation($"Worker is stopped at {DateTime.Now}");
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var delayMs = _configuration.GetValue<int>("BackgroundWorkers:StoreHwInfoElementWorker:DelayMs");

            while (!cancellationToken.IsCancellationRequested)
            {
                var sensorElements = _repository.GetSensorElements();
                var sensorReadingElements = _repository.GetSensorReadingElements();

                var hwInfoElement = HwInfoElement.Create(sensorElements, sensorReadingElements);

                await _store.Store(hwInfoElement, cancellationToken);

                _logger.LogInformation($"Worker successfully stored an hwInfo Element at {DateTime.Now}");

                await Task.Delay(delayMs, cancellationToken);
            }
        }
    }
}
