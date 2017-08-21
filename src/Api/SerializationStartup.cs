using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

static internal class SerializationStartup
{
    public static void Configuration(HttpConfiguration config)
    {
        config.Formatters.Remove(config.Formatters.XmlFormatter);
        config.Formatters.Remove(config.Formatters.FormUrlEncodedFormatter);
        config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter> { new StringEnumConverter(), new IsoDateTimeConverter() },
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}