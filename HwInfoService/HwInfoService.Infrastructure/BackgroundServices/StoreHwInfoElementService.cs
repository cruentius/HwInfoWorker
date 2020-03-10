using HwInfoService.Domain.AggregatesModel.HwInfoElementAggregate;
using HwInfoService.Domain.SeedWork;
using HwInfoService.Infrastructure.Connectors.ElasticSearchDbStores.HwInfoElements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HwInfoService.Infrastructure.BackgroundServices
{
    public class StoreHwInfoElementService : BackgroundService, IBackgroundService
    {
        private readonly ILogger<StoreHwInfoElementService> _logger;
        private readonly IHwInfoElementsStore _store;
        private readonly IHwInfoRepository _repository;
        private readonly IConfiguration _configuration;

        public StoreHwInfoElementService(ILogger<StoreHwInfoElementService> logger, IHwInfoElementsStore store, IHwInfoRepository repository, IConfiguration configuration)
        {
            _logger = logger;
            _store = store;
            _repository = repository;
            _configuration = configuration;
        }

        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            _logger.LogInformation($"Service is started at {DateTime.Now}");
        }

        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            _logger.LogInformation($"Service is stopped at {DateTime.Now}");
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var delayMs = _configuration.GetValue<int>("BackgroundServices:StoreHwInfoElementService:DelayMs");

            while (!cancellationToken.IsCancellationRequested)
            {
                var sensorElements = _repository.GetSensorElements();
                var sensorReadingElements = _repository.GetSensorReadingElements();

                var hwInfoElement = HwInfoElement.Create(sensorElements, sensorReadingElements);

                await _store.Store(hwInfoElement, cancellationToken);

                _logger.LogInformation($"Service successfully stored an hwInfo Element at {DateTime.Now}");

                await Task.Delay(delayMs, cancellationToken);
            }
        }
    }
}
