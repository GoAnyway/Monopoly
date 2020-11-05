using System;
using System.Threading.Tasks;
using Models;
using Models.AuthenticationModels;

namespace DataManager.UserStorages
{
    public interface IUserStorage
    {
        Task<GenericResultModel<UserModel>> GetUserById(Guid id);
        Task<GenericResultModel<UserModel>> Authenticate(AuthenticationModel model);
        Task<GenericResultModel<UserModel>> Register(RegistrationModel model);
    }
}