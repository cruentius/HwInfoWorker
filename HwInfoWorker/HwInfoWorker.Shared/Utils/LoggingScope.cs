using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HwInfoWorker.Shared.Utils
{
    public class LoggingScope : Dictionary<string, object>
    {
        public static LoggingScope Create()
        {
            return new LoggingScope();
        }

        private LoggingScope()
        {
        }

        public new LoggingScope Add(string key, object value)
        {
            base.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, JsonSerializerSettings);
        }

        private static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            Converters = new JsonConverter[] { new StringEnumConverter() },
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };
    }
}
