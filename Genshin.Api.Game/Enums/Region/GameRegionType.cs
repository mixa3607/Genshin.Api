using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Enums
{
    [JsonConverter(typeof(GameRegionTypeConverter))]
    public enum GameRegionType : byte
    {
        OsUsa,
        OsEurope,
        OsAsia,
        OsChina,
    }
}