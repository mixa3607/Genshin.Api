using ArkProjects.Genshin.Api.Web.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web.ChangePassword
{
    public class CreateMmtResult : IWebApiData
    {
        public string Info { get; set; }
        public string Message { get; set; }
        public WebApiDataCodeType Status { get; set; }

        [JsonProperty("mmt_data")]
        public MmtData MmtData { get; set; }

        [JsonProperty("mmt_type")]
        public int MmtType { get; set; }

        [JsonProperty("scene_type")]
        public int SceneType { get; set; }
    }
}