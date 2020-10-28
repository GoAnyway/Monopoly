using System;
using System.Threading.Tasks;
using Models.AuthenticationModels;

namespace DataManager
{
    public interface IUserStorage
    {
        Task<GenericResultModel<UserModel>> GetUserById(Guid id);
        Task<GenericResultModel<UserModel>> Authenticate(AuthenticationModel model);
        Task<GenericResultModel<UserModel>> Register(RegistrationModel model);
    }
}