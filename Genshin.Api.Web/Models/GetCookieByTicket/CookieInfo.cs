using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web.GetCookieByTicket
{
    public class CookieInfo
    {
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("cookie_token")]
        public string CookieToken { get; set; }

        [JsonProperty("cur_time")]
        public int CurTime { get; set; }

        [JsonProperty("google_name")]
        public string GoogleName { get; set; }
    }
}