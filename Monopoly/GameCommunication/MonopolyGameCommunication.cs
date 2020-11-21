using System;
using System.Threading.Tasks;
using AutoMapper;
using DataManager.GameStorages;
using Game.Logic;
using Models.GameModels;
using Models.HomeModels;

namespace Monopoly.GameCommunication
{
    public class MonopolyGameCommunication
    {
        private readonly IMonopolyGameStorage _gameStorage;
        private readonly Mapper _mapper;
        private readonly MonopolyGameLogic _monopolyGameLogic = new MonopolyGameLogic();

        public MonopolyGameCommunication(IMonopolyGameStorage gameStorage, Mapper mapper)
        {
            _gameStorage = gameStorage;
            _mapper = mapper;
        }

        public async Task<Guid> CreateGameAndGetId(GameCreationModel gameCreationModel)
        {
            var gameId = await _gameStorage.CreateGame(gameCreationModel);

            return gameId;
        }

        public Task MakeMove(MonopolyGameModel resultData)
        {
            throw new NotImplementedException();
        }
    }
}