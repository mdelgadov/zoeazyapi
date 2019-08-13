using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ZoEazy.Api.Helpers
{
    public static class Json
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        });
        }

    }
}

