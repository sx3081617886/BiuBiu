using System;
using MessagePack;

namespace BiuBiuShare.Response
{
    [MessagePackObject(true)]
    public class AdministrantSignInResponse : CommonSignInResponse
    {
        public static AdministrantSignInResponse Failed { get; }
            = new AdministrantSignInResponse() { Success = false };

        public AdministrantSignInResponse()
        {
        }

        public AdministrantSignInResponse(long userId, string displayName
            , byte[] token, DateTimeOffset expiration)
        {
            Success = true;
            UserId = userId;
            DisplayName = displayName;
            Token = token;
            Expiration = expiration;
        }
    }
}