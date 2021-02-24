using ArkProjects.Genshin.Api.Web.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web
{
    public interface IWebApiData
    {
        [JsonProperty("info")]
        string Info { get; set; }

        [JsonProperty("msg")]
        string Message { get; set; }

        [JsonProperty("status")]
        WebApiDataCodeType Status { get; set; }
    }
}