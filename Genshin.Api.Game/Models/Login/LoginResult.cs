using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class LoginResult
    {
        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("device_grant_required")]
        public bool DeviceGrantRequired { get; set; }

        [JsonProperty("safe_moblie_required")] //yes, typo in genshin api
        public bool SafeMobileRequired { get; set; }

        [JsonProperty("realperson_required")]
        public bool RealPersonRequired { get; set; }
    }
}