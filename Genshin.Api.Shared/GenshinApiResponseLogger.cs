using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArkProjects.Genshin.Api.Shared
{
    public class GenshinApiResponseLogger : IGenshinApiResponseLogger
    {
        public void LogJson(string json)
        {
            Console.WriteLine(PrettyJson(json));
        }

        private string PrettyJson(string unPrettyJson)
        {
            var jObj = JsonConvert.DeserializeObject<JObject>(unPrettyJson);
            return JsonConvert.SerializeObject(jObj, Formatting.Indented);
        }
    }
}