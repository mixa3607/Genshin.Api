using ArkProjects.Genshin.Api.Web.Enums;

namespace ArkProjects.Genshin.Api.Web.ChangePassword
{
    public class ResetPassResult : IWebApiData
    {
        public string Info { get; set; }
        public string Message { get; set; }
        public WebApiDataCodeType Status { get; set; }
    }
}