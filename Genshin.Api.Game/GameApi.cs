using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArkProjects.Genshin.Api.Game.Enums;
using ArkProjects.Genshin.Api.Game.Exceptions;
using ArkProjects.Genshin.Api.Game.Models;
using ArkProjects.Genshin.Api.Shared;
using Flurl.Http;
using Newtonsoft.Json;

namespace ArkProjects.Genshin.Api.Game
{
    public class GameApi
    {
        private const int DefaultAuthKeyVer = 1;
        public LangType Lang { get; init; } = LangType.English;
        public string GameBiz { get; init; } = GameBizes.GenshinImpact.Global;
        public GameRegionType RegionType { get; init; } = GameRegionType.OsEurope;

        private readonly int _authKeyVer;
        private readonly string? _authKey;

        private readonly string? _login;
        private readonly string? _password;
        private readonly string? _publicRsaKey;

        private string? _loginTicket;
        private string? _cookieToken;
        private int _accountId = -1;

        private readonly IGenshinApiResponseLogger? _apiResponseLogger;

        public GameApi(string login, string password, string publicKey, IGenshinApiResponseLogger? apiResponseLogger)
        {
            _apiResponseLogger = apiResponseLogger;
            _login = login;
            _password = password;
            _publicRsaKey = publicKey;
        }

        public GameApi(string login, string password, IGenshinApiResponseLogger? apiResponseLogger) : this(login, password, GenshinDefaultRsa.PublicKey, apiResponseLogger)
        {
        }

        public GameApi(string authKey, int authKeyVer, IGenshinApiResponseLogger? apiResponseLogger)
        {
            _apiResponseLogger = apiResponseLogger;
            _authKey = authKey;
            _authKeyVer = authKeyVer;
        }

        public GameApi(string authKey, IGenshinApiResponseLogger? apiResponseLogger) : this(authKey, DefaultAuthKeyVer, apiResponseLogger)
        {
        }

        public async Task<LoginResult> LoginAsync()
        {
            if (_login == null || _password == null)
            {
                throw new InvalidOperationException("For use this method you must provide login and password");
            }

            var result = await GetAsync<LoginResult>(GameApiUrls.Global.Login,
                new
                {
                    is_crypto = true,
                    account = _login,
                    password = ComputeRsaPassword()
                }, new RequestOptions());


            _loginTicket = result.Account.Token;
            _accountId = int.Parse(result.Account.Uid);

            return result;
        }

        public async Task<GetRoleResult> GetRoleByAidAndRegionAsync()
        {
            var result = await GetAsync<GetRoleResult>(GameApiUrls.Common.RoleByAidAndRegion,
                null, new RequestOptions()
                {
                    AddGameBiz = true,
                    AddRegion = true,
                    AddCookies = true
                });

            return result;
        }

        public async Task<dynamic> RedeemCodeAsync(string uid, string code)
        {
            var result = await GetAsync<dynamic>(GameApiUrls.Common.RedeemCode,
                new {uid, cdkey = code}, new RequestOptions()
                {
                    AddGameBiz = true,
                    AddRegion = true,
                });

            return result;
        }

        public async Task<GetGachaTypesResult> GetGachaListAsync()
        {
            var result = await GetAsync<GetGachaTypesResult>(GameApiUrls.Event.GachaList,
                null, new RequestOptions()
                {
                    AddGameBiz = true,
                    AddRegion = true,
                    AddAuthQuery = true
                });

            return result;
        }

        public async Task<GetGachaLogResult> GetGachaLogAsync(int page, int size, int type)
        {
            var result = await GetAsync<GetGachaLogResult>(GameApiUrls.Event.GachaLog,
                new {page, size, gacha_type = type}, new RequestOptions()
                {
                    AddGameBiz = true,
                    AddRegion = true,
                    AddAuthQuery = true
                });

            return result;
        }

        /// <summary>
        /// Retrieve all gacha log pages in loop. Not recommend for use.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<GachaLogEntry>> GetGachaFullLogAsync(int type)
        {
            var log = new List<GachaLogEntry>();
            for (var pageNum = 1;; pageNum++)
            {
                var page = await GetGachaLogAsync(pageNum, 10, type);
                if (page.Log.Count == 0)
                    break;
                log.AddRange(page.Log);
            }

            return log;
        }

        private async Task<T> GetAsync<T>(string url, object? query, RequestOptions opts, object? cookies = null)
        {
            var json = await BuildBaseRequest(url, query, cookies, opts).GetStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponse<T>>(json);
            _apiResponseLogger?.LogJson(json);
            ThrowIfNotOk(result, json);

            return result.Data;
        }

        private IFlurlRequest BuildBaseRequest(string url, object? query, object? cookies, RequestOptions opts)
        {
            IFlurlRequest req = new FlurlRequest(url);

            req = req.SetQueryParam("lang", Lang.ToShortStr());

            if (query != null)
                req = req.SetQueryParams(query);
            if (cookies != null)
                req = req.WithCookies(cookies);

            if (opts.AddRegion)
                req = req.SetQueryParam("region", GameRegionTypeConverter.ConvToStr(RegionType));
            if (opts.AddGameBiz)
                req = req.SetQueryParam("game_biz", GameBiz);

            if (opts.AddAuthQuery)
            {
                if (_authKey == null)
                {
                    throw new InvalidOperationException("For use authKey you must provide it");
                }

                req = req
                    .SetQueryParam("authkey_ver", _authKeyVer)
                    .SetQueryParam("authkey", _authKey);
            }

            if (opts.AddCookies)
            {
                if (_loginTicket == null || _cookieToken == null || _accountId == -1)
                {
                    throw new InvalidOperationException("For use cookies you must be login");
                }

                req = req
                    .WithCookie("login_ticket", _loginTicket)
                    .WithCookie("account_id", _accountId)
                    .WithCookie("cookie_token", _cookieToken);
            }

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
        private static void ThrowIfNotOk<T>(ApiResponse<T> response, string json)
        {
            if (response.ReturnCode != GameReturnCodeType.Ok)
            {
                throw new GameResponseException(json, response.Message, response.ReturnCode);
            }
        }
    }
}