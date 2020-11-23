using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities.UserEntity;
using Models;
using Models.AuthenticationModels;
using Utils;
using Utils.Extensions;

namespace DataManager.UserStorages.StubStorage
{
    public class StubUserStorage : IUserStorage
    {
        private readonly Mapper _mapper;
        private readonly IList<User> _users;

        public StubUserStorage(Mapper mapper)
        {
            _mapper = mapper;

            var salt = $"{Guid.NewGuid():N}";
            var salt2 = $"{Guid.NewGuid():N}";

            _users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(), Username = "User", Email = "test@mail.ru", PasswordHash = $"1234{salt}".Md5(),
                    Salt = salt, Balance = 500, Nickname = "BestPlayer", LastLoginTime = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(), Username = "User2", Email = "test2@mail.ru",
                    PasswordHash = $"4321{salt2}".Md5(),
                    Salt = salt2, Balance = 500, Nickname = "JustPlayer", LastLoginTime = DateTime.UtcNow
                }
            };
        }

        public async Task<GenericResultModel<UserModel>> GetUserById(Guid id)
        {
            var result = new GenericResultModel<UserModel>
            {
                Success = true
            };

            var user = _users.FirstOrDefault(_ => _.Id == id);

            if (user == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("User is not found.");
            }
            else
            {
                result.Data = _mapper.Map<UserModel>(user);
            }

            await Task.CompletedTask;
            return result;
        }

        public async Task<GenericResultModel<UserModel>> Authenticate(AuthenticationModel model)
        {
            var result = new GenericResultModel<UserModel>
            {
                Success = true
            };

            var user = _users.FirstOrDefault(_ => _.Username == model.Username);
            var hash = $"{model.Password}{user?.Salt}".Md5();

            if (user == null || user.PasswordHash != hash)
            {
                result.Success = false;
                result.Error = new ErrorModel("Incorrect Username or Password.");

                return result;
            }

            result.Data = _mapper.Map<UserModel>(user);

            await Task.CompletedTask;
            return result;
        }

        public async Task<GenericResultModel<UserModel>> Register(RegistrationModel model)
        {
            var result = new GenericResultModel<UserModel>
            {
                Success = true
            };

            if (_users.Any(_ => _.Username == model.Username ||
                                _.Email == model.Email ||
                                _.Nickname == model.Nickname))
            {
                result.Success = false;
                result.Error = new ErrorModel("A user with this Username/Email/Nickname already exists.");
            }
            else
            {
                var user = _mapper.Map<User>(model);

                _users.Add(user);

                result.Data = _mapper.Map<UserModel>(user);
            }

            await Task.CompletedTask;
            return result;
        }
    }
}