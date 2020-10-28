using AutoMapper;
using Models.AuthenticationModels;
using Models.GameModels;
using Models.HomeModels;

namespace Utils.MapperProfiles
{
    public class MonopolyGameProfile : Profile
    {
        public MonopolyGameProfile()
        {
            CreateMap<UserModel, PlayerModel>()
                .ForMember(_ => _.User, opt => opt.MapFrom(s => s));

            CreateMap<GameCreationModel, MonopolyGameModel>()
                .ForMember(_ => _.Players, opt => opt.MapFrom(s => s.Players));
        }
    }
}