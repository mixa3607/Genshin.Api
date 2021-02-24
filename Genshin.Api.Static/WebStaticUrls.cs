using ArkProjects.Genshin.Api.Game.Enums;
using ArkProjects.Genshin.Api.Shared;

namespace ArkProjects.Genshin.Api.Static
{
    public class WebStaticUrls
    {
        public const string Host = "https://webstatic-sea.mihoyo.com";

        public static string GetGachaItemsUrl(GameRegionType region ,LangType lang)
        {
            var project = "hk4e";
            return $"{Host}/{project}/gacha_info/{GameRegionTypeConverter.ConvToStr(region)}/items/{lang.ToFullStr()}.json";
        }
    }
}