using System;
using AutoMapper;
using Database.Entities.UserEntity;
using Models.AuthenticationModels;
using Utils.Extensions;

namespace Utils.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.PasswordHash))
                .ForMember(_ => _.Role, opt => opt.MapFrom(s => s.Role))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname))
                .ForMember(_ => _.RegistrationTime, opt => opt.MapFrom(s => s.RegistrationTime))
                .ForMember(_ => _.LastLoginTime, opt => opt.MapFrom(s => s.LastLoginTime));
            CreateMap<UserModel, User>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(_ => _.PasswordHash, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Role, opt => opt.MapFrom(s => s.Role))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname))
                .ForMember(_ => _.RegistrationTime, opt => opt.MapFrom(s => s.RegistrationTime))
                .ForMember(_ => _.LastLoginTime, opt => opt.MapFrom(s => s.LastLoginTime));

            CreateMap<User, RegistrationModel>()
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.PasswordHash))
                .ForMember(_ => _.ConfirmPassword, opt => opt.MapFrom(s => s.PasswordHash))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email));
            CreateMap<RegistrationModel, User>()
                .BeforeMap((model, user) => { user.Salt = $"{Guid.NewGuid():N}"; })
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .AfterMap((model, user) => { user.PasswordHash = $"{model.Password}{user.Salt}".Md5(); });

            CreateMap<User, AuthenticationModel>()
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.PasswordHash));
            CreateMap<AuthenticationModel, User>()
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.PasswordHash, opt => opt.MapFrom(s => s.Password.Md5()))
                .AfterMap((model, user) => { user.LastLoginTime = DateTime.UtcNow; });
        }
    }
}