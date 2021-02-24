using System;
using ArkProjects.Genshin.Api.Game.Enums;

namespace ArkProjects.Genshin.Api.Game.Exceptions
{
    public class GameResponseException : Exception
    {
        public GameReturnCodeType ReturnCode { get; }
        public string ResponseJson { get; }

        public GameResponseException(string json, string message, GameReturnCodeType returnCode) : base($"[{returnCode}] {message}")
        {
            ReturnCode = returnCode;
            ResponseJson = json;
        }
    }
}