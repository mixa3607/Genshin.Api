using System.Collections.Generic;
using ArkProjects.Genshin.Api.Game.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class GetGachaLogResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("list")]
        public List<GachaLogEntry> Log { get; set; }

        [JsonProperty("region")]
        public GameRegionType RegionType { get; set; }
    }
}