using ArkProjects.Genshin.Api.Game.Enums;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty("retcode")]
        public GameReturnCodeType ReturnCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}