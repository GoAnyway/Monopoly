using System.Security.Claims;
using System.Threading.Tasks;
using Models.AuthenticationModels;

namespace Monopoly.Authentication
{
    public interface IAuthentication
    {
        Task<UserModel> GetUserByClaim(ClaimsPrincipal claimsPrincipal);
    }
}