using System;
using System.Threading;
using BiuBiuServer.Tests;
using BiuBiuShare;
using BiuBiuShare.Response;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using MagicOnion.Server.Authentication;
using MagicOnion.Server.Authentication.Jwt;

namespace BiuBiuServer.Services
{
    public class AccountService : ServiceBase<IAccountService>, IAccountService
    {
        private readonly IAccountVerify _iAccountVerify = new AccountVerifyTest();

        private readonly IJwtAuthenticationProvider _jwtAuthProvider;

        public AccountService(IJwtAuthenticationProvider jwtAuthProvider)
        {
            _jwtAuthProvider = jwtAuthProvider ??
                               throw new ArgumentNullException(
                                   nameof(jwtAuthProvider));
        }

        [AllowAnonymous]
        public async UnaryResult<CommonSignInResponse> CommonSignInAsync(
            string signInId, string password)
        {
            var commonSignInResponse
                = await _iAccountVerify.CommonSign(signInId, password);
            if (commonSignInResponse.Success == true)
            {
                var encodedPayload = _jwtAuthProvider.CreateTokenFromPayload(
                    new CustomJwtAuthenticationPayload()
                    {
                        UserId = commonSignInResponse.UserId
                        ,
                        DisplayName = commonSignInResponse.DisplayName
                        ,
                        IsAdmin = false
                    });
                commonSignInResponse.Token = encodedPayload.Token;
                commonSignInResponse.Expiration = encodedPayload.Expiration;
            }

            return commonSignInResponse;
        }

        [AllowAnonymous]
        public async UnaryResult<AdministrantSignInResponse>
            AdministrantSignInAsync(string signInId, string password)
        {
            var administrantSignInResponse
                = await _iAccountVerify.AdministrantSign(signInId, password);
            if (administrantSignInResponse.Success == true)
            {
                var encodedPayload = _jwtAuthProvider.CreateTokenFromPayload(
                    new CustomJwtAuthenticationPayload()
                    {
                        UserId = administrantSignInResponse.UserId
                        ,
                        DisplayName
                            = administrantSignInResponse.DisplayName
                        ,
                        IsAdmin = true
                    });
                administrantSignInResponse.Token = encodedPayload.Token;
                administrantSignInResponse.Expiration
                    = encodedPayload.Expiration;
                return administrantSignInResponse;
            }

            return administrantSignInResponse;
        }
    }
}