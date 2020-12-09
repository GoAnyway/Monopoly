using System.Linq;
using AutoMapper;
using Database.Entities.GameEntities;
using Database.Entities.GameEntities.GameBoardObjects;
using Models.AuthenticationModels;
using Models.GameModels;
using Models.GameModels.CellModels;
using Models.HomeModels;

namespace Utils.MapperProfiles
{
    public class MonopolyGameProfile : Profile
    {
        public MonopolyGameProfile()
        {
            CreateMap<UserModel, PlayerModel>()
                .ForMember(_ => _.User, opt => opt.MapFrom(s => s));

            CreateMap<Player, PlayerModel>()
                .ForMember(_ => _.User, opt => opt.MapFrom(s => s.User))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.PropertiesInOwnership, opt => opt.MapFrom(s => s.PropertiesInOwnership))
                .ForMember(_ => _.IsAlive, opt => opt.MapFrom(s => s.IsAlive))
                .ForMember(_ => _.CurrentCell, opt => opt.MapFrom(s => s.CurrentCell))
                .ForMember(_ => _.NextPlayer, opt => opt.MapFrom(s => s.NextPlayer));
            CreateMap<PlayerModel, Player>()
                .ForMember(_ => _.User, opt => opt.MapFrom(s => s.User))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.PropertiesInOwnership, opt => opt.MapFrom(s => s.PropertiesInOwnership))
                .ForMember(_ => _.IsAlive, opt => opt.MapFrom(s => s.IsAlive))
                .ForMember(_ => _.CurrentCell, opt => opt.MapFrom(s => s.CurrentCell))
                .ForMember(_ => _.NextPlayer, opt => opt.MapFrom(s => s.NextPlayer));

            CreateMap<GameCreation, GameCreationModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(_ => _.Owner, opt => opt.MapFrom(s => s.Owner))
                .ForMember(_ => _.Players, opt => opt.MapFrom(s => s.Players))
                .ForMember(_ => _.NumberOfPlayers, opt => opt.MapFrom(s => s.NumberOfPlayers))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password));
            CreateMap<GameCreationModel, GameCreation>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(_ => _.Owner, opt => opt.MapFrom(s => s.Owner))
                .ForMember(_ => _.Players, opt => opt.MapFrom(s => s.Players))
                .ForMember(_ => _.NumberOfPlayers, opt => opt.MapFrom(s => s.NumberOfPlayers))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password));

            CreateMap<GameCreationModel, MonopolyGame>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Players, opt => opt.MapFrom(s => s.Players))
                .AfterMap((model, game) =>
                {
                    for (var i = 0; i < game.Players.Count - 1; i++)
                    {
                        game.Players[i].NextPlayer = game.Players[(i + 1) % game.Players.Count];
                    }
                });

            CreateMap<MonopolyGame, MonopolyGameModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.GameBoard, opt => opt.MapFrom(s => s.GameBoard))
                .ForMember(_ => _.Players, opt => opt.MapFrom(s => s.Players))
                .ForMember(_ => _.Turn, opt => opt.MapFrom(s => s.Turn))
                .ForMember(_ => _.ActivePlayer, opt => opt.MapFrom(s => s.ActivePlayer))
                .ForMember(_ => _.StartTime, opt => opt.MapFrom(s => s.StartTime))
                .ForMember(_ => _.FinishTime, opt => opt.MapFrom(s => s.FinishTime))
                .ForMember(_ => _.LastUpdateTime, opt => opt.MapFrom(s => s.LastUpdateTime));
            CreateMap<MonopolyGameModel, MonopolyGame>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.GameBoard, opt => opt.MapFrom(s => s.GameBoard))
                .ForMember(_ => _.Players, opt => opt.MapFrom(s => s.Players))
                .ForMember(_ => _.Turn, opt => opt.MapFrom(s => s.Turn))
                .ForMember(_ => _.ActivePlayer, opt => opt.MapFrom(s => s.ActivePlayer))
                .ForMember(_ => _.StartTime, opt => opt.MapFrom(s => s.StartTime))
                .ForMember(_ => _.FinishTime, opt => opt.MapFrom(s => s.FinishTime))
                .ForMember(_ => _.LastUpdateTime, opt => opt.MapFrom(s => s.LastUpdateTime));

            CreateMap<Cell, CellModel>()
                .ForMember(_ => _.Index, opt => opt.MapFrom(s => s.Index));
            CreateMap<CellModel, Cell>()
                .ForMember(_ => _.Index, opt => opt.MapFrom(s => s.Index));
        }
    }
}