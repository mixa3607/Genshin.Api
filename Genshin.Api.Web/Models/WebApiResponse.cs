using ArkProjects.Genshin.Api.Web.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web
{
    public class WebApiResponse<T>
    {
        [JsonProperty("code")]
        public WebReturnCodeType ReturnCode { get; set; }

        public T Data { get; set; }
    }
}