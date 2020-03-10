using DearNova.ApplicationConfiguration;

namespace HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.Configuration
{
    public class ElasticSearchStoreConfiguration : ApplicationConfigurationBase
    {
        public override string Name => ElasticSearchStoreConstants.Name;
        public string EndpointAddress { get; set; }
        public string IndexName { get; set; }
    }
}
