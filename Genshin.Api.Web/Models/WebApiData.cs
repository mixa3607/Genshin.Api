using ArkProjects.Genshin.Api.Web.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web
{
    public class WebApiData : IWebApiData
    {
        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("status")]
        public WebApiDataCodeType Status { get; set; }
    }
}