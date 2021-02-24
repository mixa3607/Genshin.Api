using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{

    public class GachaType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}