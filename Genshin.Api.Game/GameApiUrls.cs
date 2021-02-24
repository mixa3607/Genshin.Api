namespace ArkProjects.Genshin.Api.Game
{
    public static class GameApiUrls
    {
        public const string Host = "https://hk4e-api-os.mihoyo.com";

        public static class Global
        {
            public const string Login = Host + "/hk4e_global/mdk/shield/api/login";
        }

        public static class Common
        {
            public const string RoleByAidAndRegion = Host + "/common/apicdkey/api/getRoleByAidAndRegion";
            public const string RedeemCode = Host + "/common/apicdkey/api/webExchangeCdkey";
        }

        public static class Event
        {
            public const string GachaList = Host + "/event/gacha_info/api/getConfigList";
            public const string GachaLog = Host + "/event/gacha_info/api/getGachaLog";
        }
    }
}