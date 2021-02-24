using System.Collections.Generic;
using System.Threading.Tasks;
using ArkProjects.Genshin.Api.Game.Enums;
using ArkProjects.Genshin.Api.Shared;
using Flurl.Http;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Static
{
    public class WebStatic
    {
        public LangType Lang { get; init; } = LangType.English;
        public GameRegionType RegionType { get; init; } = GameRegionType.OsEurope;

        private readonly IGenshinApiResponseLogger? _apiResponseLogger;

        public WebStatic(IGenshinApiResponseLogger? apiResponseLogger)
        {
            _apiResponseLogger = apiResponseLogger;
        }

        public async Task<IReadOnlyCollection<GachaItem>> GetGachaItemsAsync()
        {
            var result = await GetAsync<GachaItem[]>(WebStaticUrls.GetGachaItemsUrl(RegionType, Lang));
            return result;
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var json = await url.GetStringAsync();
            var result = JsonConvert.DeserializeObject<T>(json);
            _apiResponseLogger?.LogJson(json);

            return result;
        }
    }
}