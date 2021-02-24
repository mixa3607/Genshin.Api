using System;
using ArkProjects.Genshin.Api.Web.Enums;

namespace ArkProjects.Genshin.Api.Web
{
    public class WebApiResponseException : Exception
    {
        public WebReturnCodeType ReturnCode { get; }
        public string ResponseJson { get; }

        public WebApiResponseException(string json, string message, WebReturnCodeType returnCode) : base($"[{returnCode}] {message}")
        {
            ReturnCode = returnCode;
            ResponseJson = json;
        }
    }
}