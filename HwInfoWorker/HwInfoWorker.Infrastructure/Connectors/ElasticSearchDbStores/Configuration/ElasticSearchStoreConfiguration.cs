namespace HwInfoWorker.Infrastructure.Connectors.ElasticSearchDbStores.Configuration
{
    public class ElasticSearchStoreConfiguration
    {
        public string EndpointAddress { get; set; }
        public string IndexName { get; set; }
        public int TimeoutMs { get; set; }
        public int MaxRetries { get; set; }
    }
}
