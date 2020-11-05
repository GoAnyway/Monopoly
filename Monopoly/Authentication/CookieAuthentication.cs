using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataManager.UserStorages;
using Models.AuthenticationModels;

namespace Monopoly.Authentication
{
    public class CookieAuthentication : IAuthentication
    {
        private readonly IUserStorage _storage;

        public CookieAuthentication(IUserStorage storage)
        {
            _storage = storage;
        }

        public async Task<UserModel> GetUserByClaim(ClaimsPrincipal claimsPrincipal)
        {
            var userId = Guid.Parse(claimsPrincipal.Claims.Single(_ => _.Type == "UserId").Value);
            var result = await _storage.GetUserById(userId);

            return result.Data;
        }
    }
}