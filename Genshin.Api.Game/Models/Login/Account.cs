using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class Account
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("is_email_verify")]
        public string IsEmailVerify { get; set; }

        [JsonProperty("realname")]
        public string RealName { get; set; }

        [JsonProperty("identity_card")]
        public string IdentityCard { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("safe_mobile")]
        public string SafeMobile { get; set; }

        [JsonProperty("facebook_name")]
        public string FacebookName { get; set; }

        [JsonProperty("google_name")]
        public string GoogleName { get; set; }

        [JsonProperty("twitter_name")]
        public string TwitterName { get; set; }

        [JsonProperty("game_center_name")]
        public string GameCenterName { get; set; }

        [JsonProperty("apple_name")]
        public string AppleName { get; set; }

        [JsonProperty("sony_name")]
        public string SonyName { get; set; }

        [JsonProperty("tap_name")]
        public string TapName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}