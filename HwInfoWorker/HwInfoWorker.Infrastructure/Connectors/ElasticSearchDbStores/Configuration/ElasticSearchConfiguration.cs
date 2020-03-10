using DearNova.ApplicationConfiguration;

namespace HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.Configuration
{
    public class ElasticSearchConfiguration : ApplicationConfigurationBase
    {
        public override string Name => ElasticSearchConstants.Name;
        public string EndpointAddress { get; set; }
        public string IndexName { get; set; }
    }
}
