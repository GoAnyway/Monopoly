using System;
using System.Threading.Tasks;
using AutoMapper;
using Database;
using Database.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using Models.AuthenticationModels;
using Utils;

namespace DataManager.DbStorage
{
    public class DbUserStorage : IUserStorage
    {
        private readonly MonopolyContext _context;
        private readonly Mapper _mapper;

        public DbUserStorage(MonopolyContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenericResultModel<UserModel>> GetUserById(Guid id)
        {
            var result = new GenericResultModel<UserModel>
            {
                Success = true
            };

            var user = await _context.Users.FindAsync();

            if (user == null)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Message = "User is not found."
                };
            }
            else
            {
                result.Data = _mapper.Map<UserModel>(user);
            }

            return result;
        }

        public async Task<GenericResultModel<UserModel>> Authenticate(AuthenticationModel model)
        {
            var result = new GenericResultModel<UserModel>
            {
                Success = true
            };

            var user = await _context.Users.FirstOrDefaultAsync(_ => _.Username == model.Username);
            var hash = $"{model.Password}{user?.Salt}".Md5();

            if (user == null || user.PasswordHash != hash)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Message = "Incorrect Username or Password."
                };

                return result;
            }

            result.Data = _mapper.Map<UserModel>(user);

            return result;
        }

        public async Task<GenericResultModel<UserModel>> Register(RegistrationModel model)
        {
            var result = new GenericResultModel<UserModel>
            {
                Success = true
            };

            if (await _context.Users.AnyAsync(_ => _.Username == model.Username ||
                                                   _.Email == model.Email ||
                                                   _.Nickname == model.Nickname))
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Message = "A user with this Username/Email/Nickname already exists."
                };
            }
            else
            {
                var user = _mapper.Map<User>(model);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                result.Data = _mapper.Map<UserModel>(user);
            }

            return result;
        }
    }
}