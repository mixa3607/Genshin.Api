using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class GetRoleResult
    {
        [JsonProperty("uid")]
        public string UserId { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }
    }
}