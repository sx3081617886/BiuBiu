using BiuBiuShare.Response;
using MagicOnion;

namespace BiuBiuServer.Services
{
    public interface IAccountVerify
    {
        public UnaryResult<CommonSignInResponse> CommonSign(string signInId
            , string password);

        public UnaryResult<AdministrantSignInResponse> AdministrantSign(
            string signInId, string password);
    }
}