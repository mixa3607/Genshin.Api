using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web.Login
{
    public class AccountInfo
    {
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("google_name")]
        public string GoogleName { get; set; }

        [JsonProperty("safe_level")]
        public int SafeLevel { get; set; }

        [JsonProperty("weblogin_token")]
        public string WebLoginToken { get; set; }
    }
}