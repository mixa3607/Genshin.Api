using System;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class GachaLogEntry
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("gacha_type")]
        public int GachaType { get; set; }

        [JsonProperty("item_id")]
        public int ItemId { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return $"{Uid} {Time} {GachaType} {ItemId} {Count}";
        }
    }
}