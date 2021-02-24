namespace ArkProjects.Genshin.Api.Web
{
    public static class WebApiUrls
    {
        public const string Host = "https://webapi-os.account.mihoyo.com";
        public const string Login = Host + "/Api/login_by_password";
        public const string CookieByTicket = Host + "/Api/cookie_accountinfo_by_loginticket";
        public const string ResetPassword = Host + "/Api/verify_email_captcha";
        public const string CreateMmt = Host + "/Api/create_mmt";
    }
}