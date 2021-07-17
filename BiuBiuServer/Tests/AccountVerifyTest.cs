using System;
using System.Collections.Generic;
using BiuBiuServer.Services;
using BiuBiuShare.Response;
using MagicOnion;

namespace BiuBiuServer.Tests
{
    public class AccountVerifyTest : IAccountVerify
    {
        private static readonly
            IDictionary<string, (string Password, long UserId, string
                DisplayName)> _dummyUsers
                = new Dictionary<string, (string, long, string)>(StringComparer
                    .OrdinalIgnoreCase)
                {
                    {"1776137198", ("123456789", 1001, "Eustiana von Astraea")}
                    , {"1250236422", ("123456789", 1002, "Kiruya Momochi")}
                    ,
                };

        private static readonly
            IDictionary<string, (string Password, long UserId, string
                DisplayName)> _adminDummyUsers
                = new Dictionary<string, (string, long, string)>(StringComparer
                    .OrdinalIgnoreCase)
                {
                    {"1250236422", ("123456789", 1002, "Kiruya Momochi")},
                };

        public async UnaryResult<CommonSignInResponse> CommonSign(
            string signInId, string password)
        {
            if (_dummyUsers.TryGetValue(signInId, out var userInfo) &&
                userInfo.Password == password)
            {
                return new CommonSignInResponse()
                {
                    DisplayName = userInfo.DisplayName
                    ,
                    UserId = userInfo.UserId
                    ,
                    Success = true
                };
            }

            ;
            return CommonSignInResponse.Failed;
        }

        public async UnaryResult<AdministrantSignInResponse> AdministrantSign(
            string signInId, string password)
        {
            if (_adminDummyUsers.TryGetValue(signInId, out var userInfo) &&
                userInfo.Password == password)
            {
                return new AdministrantSignInResponse()
                {
                    DisplayName = userInfo.DisplayName
                    ,
                    UserId = userInfo.UserId
                    ,
                    Success = true
                };
            }

            return AdministrantSignInResponse.Failed;
        }
    }
}