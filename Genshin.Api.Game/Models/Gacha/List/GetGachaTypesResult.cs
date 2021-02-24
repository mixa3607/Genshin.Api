using System.Collections.Generic;
using ArkProjects.Genshin.Api.Game.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class GetGachaTypesResult
    {
        [JsonProperty("gacha_type_list")]
        public List<GachaType> GachaList { get; set; }

        [JsonProperty("region")]
        public GameRegionType RegionType { get; set; }
    }
}