namespace ArkProjects.Genshin.Api.Game.Enums
{
    public enum GameReturnCodeType
    {
        Ok = 0, //OK
        NotValidAuthKey = -1, //authkey valid error
        PasswordError = -102, //Password error
        NeedLogin = -1071, //Please log in to your account first
        NoCharacterOnSelectedServer = -1073, //You haven't created a character on this server. Create a character first and then try redeeming the code.
        RedemptionCodeExpired = -2001, //Redemption code expired.
        RedemptionCodeInvalid = -2003, //Invalid redemption code
    }
}