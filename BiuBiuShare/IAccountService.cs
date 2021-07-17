using BiuBiuShare.Response;
using MagicOnion;

namespace BiuBiuShare
{
    public interface IAccountService : IService<IAccountService>
    {
        UnaryResult<CommonSignInResponse> CommonSignInAsync(string signInId
            , string password);

        UnaryResult<AdministrantSignInResponse> AdministrantSignInAsync(
            string signInId, string password);
    }
}