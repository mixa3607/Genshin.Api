using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArkProjects.Genshin.Api.Shared;
using ArkProjects.Genshin.Api.Web.ChangePassword;
using ArkProjects.Genshin.Api.Web.Enums;
using ArkProjects.Genshin.Api.Web.GetCookieByTicket;
using ArkProjects.Genshin.Api.Web.Login;
using Flurl.Http;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Web
{
    public class WebApi
    {
        private readonly string? _login;
        private readonly string? _password;
        private readonly string? _publicRsaKey;

        private string? _loginTicket;
        private string? _cookieToken;
        private int _accountId;
        private readonly IGenshinApiResponseLogger? _apiResponseLogger;

        public WebApi(string login, string password, string publicRsaKey, IGenshinApiResponseLogger? apiResponseLogger = null)
        {
            _login = login;
            _password = password;
            _publicRsaKey = publicRsaKey;
            _apiResponseLogger = apiResponseLogger;
        }

        public WebApi(string login, string password, IGenshinApiResponseLogger? apiResponseLogger = null) : this(login, password, GenshinDefaultRsa.PublicKey, apiResponseLogger)
        {
        }

        public WebApi(string loginTicket, string cookieToken, int uid, IGenshinApiResponseLogger? apiResponseLogger = null)
        {
            _loginTicket = loginTicket;
            _cookieToken = cookieToken;
            _accountId = uid;
            _apiResponseLogger = apiResponseLogger;
        }

        [Obsolete("Not work at this moment. Need solved captcha")]
        public async Task<AccountInfo> LoginAsync()
        {
            if (_password == null || _login == null)
            {
                throw new InvalidOperationException("For use this method you must provide login and password");
            }

            var result = await GetAsync<WebApiDataLogin>(WebApiUrls.Login,
                new {is_crypto = true, account = _login, password = ComputeRsaPassword()});

            _loginTicket = result.AccountInfo.WebLoginToken;
            _accountId = result.AccountInfo.AccountId;

            return result.AccountInfo;
        }

        public async Task<ResetPassResult> ResetPasswordAsync(string actionTicket, string code)
        {
            var result = await PostAsync<ResetPassResult>(WebApiUrls.ResetPassword,
                new Dictionary<string, object>()
                {
                    {"action_type", "change_password"},
                    {"action_ticket", actionTicket},
                    {"captcha", code}
                },
                new Dictionary<string, object>()
                {
                    {"action_type", "change_password"},
                    {"action_ticket", actionTicket},
                    {"captcha", code}
                });

            return result;
        }

        public async Task<CreateMmtResult> CreateMmtAsync()
        {
            var result = await GetAsync<CreateMmtResult>(WebApiUrls.CreateMmt,
                new {scene_type = 1, now = DateTimeOffset.Now.ToUnixTimeSeconds()});

            return result;
        }

        public async Task<CookieInfo> GetCookieAsync()
        {
            if (_loginTicket == null)
            {
                throw new InvalidOperationException("For use this method you must login");
            }

            var result = await GetAsync<WebApiDataGetCookie>(WebApiUrls.CookieByTicket,
                new {login_ticket = _loginTicket});

            _cookieToken = result.CookieInfo.CookieToken;

            return result.CookieInfo;
        }

        private async Task<T> GetAsync<T>(string url, object? query, object? cookies = null)
        {
            var json = await BuildBaseRequest(url, query, cookies).GetStringAsync();

            var result = JsonConvert.DeserializeObject<WebApiResponse<T>>(json);
            _apiResponseLogger?.LogJson(json);
            ThrowIfNotOk(result, json);

            return result.Data;
        }

        private async Task<T> PostAsync<T>(string url, object? query, object body, object? cookies = null)
        {
            var response = await BuildBaseRequest(url, query, cookies).PostUrlEncodedAsync(body);
            var json = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<WebApiResponse<T>>(json);
            _apiResponseLogger?.LogJson(json);
            ThrowIfNotOk(result, json);

            return result.Data;
        }

        private IFlurlRequest BuildBaseRequest(string url, object? query, object? cookies)
        {
            IFlurlRequest req = new FlurlRequest(url);

            if (query != null)
                req = req.SetQueryParams(query);
            if (cookies != null)
                req = req.WithCookies(cookies);

            return req;
        }

        private string ComputeRsaPassword()
        {
            var rsa = new YunYongJsEncryptHelper(null, _publicRsaKey);
            var encPassword = rsa.Encrypt(_password);
            return encPassword;
        }

        /// <summary>
        /// Throw exception if api return not 200 (ok) code
        /// </summary>
        /// <typeparam name="T">Api response object type</typeparam>
        /// <param name="response">Response</param>
        /// <param name="json">Body json</param>
        private static void ThrowIfNotOk<T>(WebApiResponse<T> response, string json)
        {
            if (response.ReturnCode != WebReturnCodeType.Ok)
            {
                throw new WebApiResponseException(json, response.ReturnCode.ToString(), response.ReturnCode);
            }
        }
    }
}