using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web.Login
{
    public class WebApiDataLogin : WebApiData
    {
        [JsonProperty("account_info")]
        public AccountInfo AccountInfo { get; set; }
    }
}