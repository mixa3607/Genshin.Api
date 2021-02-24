using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Static
{
    public class GachaItem
    {
        [JsonProperty("item_id")]
        public int ItemId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        [JsonProperty("rank_type")]
        public int RankType { get; set; }

        public override string ToString()
        {
            return $"Id: {ItemId}, {Name}, {ItemType}, S: {RankType}";
        }
    }
}