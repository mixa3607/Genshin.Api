using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web.GetCookieByTicket
{
    public class WebApiDataGetCookie : WebApiData
    {
        [JsonProperty("cookie_info")]
        public CookieInfo CookieInfo { get; set; }
    }
}