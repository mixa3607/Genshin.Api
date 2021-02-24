using System;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Enums
{
    public class GameRegionTypeConverter : JsonConverter<GameRegionType>
    {
        public const string Usa = "os_usa";
        public const string Europe = "os_euro";
        public const string Asia = "os_asia";
        public const string China = "os_cht";

        public static string ConvToStr(GameRegionType type)
        {
            var str = type switch
            {
                GameRegionType.OsAsia => Asia,
                GameRegionType.OsChina => China,
                GameRegionType.OsEurope => Europe,
                GameRegionType.OsUsa => Usa,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            return str;
        }

        public static GameRegionType ConvToType(string str)
        {
            var val = str switch
            {
                Asia => GameRegionType.OsAsia,
                China => GameRegionType.OsChina,
                Europe => GameRegionType.OsEurope,
                Usa => GameRegionType.OsUsa,
                _ => throw new ArgumentOutOfRangeException(nameof(str), str, null)
            };
            return val;
        }

        public override void WriteJson(JsonWriter writer, GameRegionType value, JsonSerializer serializer)
        {
            writer.WriteValue(ConvToStr(value));
        }

        public override GameRegionType ReadJson(JsonReader reader, Type objectType, GameRegionType existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var obj = (string) reader.Value;
            var val = ConvToType(obj);
            return val;
        }
    }
}