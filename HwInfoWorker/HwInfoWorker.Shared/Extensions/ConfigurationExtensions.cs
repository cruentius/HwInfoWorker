using Microsoft.Extensions.Configuration;

namespace HwInfoWorker.Shared.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfiguration Bind<TConfig>(this IConfiguration configuration, string configKey, out TConfig result) where TConfig : new()
        {
            result = new TConfig();
            configuration.Bind(configKey, result);

            return configuration;
        }
    }
}
