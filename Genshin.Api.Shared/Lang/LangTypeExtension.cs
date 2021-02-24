using System;

namespace ArkProjects.Genshin.Api.Shared
{
    public static class LangTypeExtension
    {
        public static string ToShortStr(this LangType type)
        {
            return type switch
            {
                LangType.English => "en",
                LangType.Russian => "ru",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static string ToFullStr(this LangType type)
        {
            return type switch
            {
                LangType.English => "en-us",
                LangType.Russian => "ru-ru",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}