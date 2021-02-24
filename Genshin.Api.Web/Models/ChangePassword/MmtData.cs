using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web.ChangePassword
{
    public class MmtData
    {
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [JsonProperty("gt")]
        public string Geetest { get; set; }

        [JsonProperty("mmt_key")]
        public string MmtKey { get; set; }

        [JsonProperty("new_captcha")]
        public int NewCaptcha { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }
    }
}