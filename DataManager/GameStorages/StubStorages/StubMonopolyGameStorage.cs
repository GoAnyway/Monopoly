using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities.GameEntities;
using Models;
using Models.AuthenticationModels;
using Models.GameModels;
using Models.HomeModels;

namespace DataManager.GameStorages.StubStorages
{
    public class StubMonopolyGameStorage : IMonopolyGameStorage
    {
        private readonly IList<MonopolyGame> _games = new List<MonopolyGame>();
        private readonly Mapper _mapper;

        public StubMonopolyGameStorage(Mapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Guid> CreateGame(GameCreationModel model)
        {
            var game = _mapper.Map<MonopolyGame>(model);

            _games.Add(game);

            await Task.CompletedTask;
            return game.Id;
        }

        public async Task<GenericResultModel<MonopolyGameModel>> GetGameById(Guid gameId)
        {
            var result = new GenericResultModel<MonopolyGameModel>
            {
                Success = true
            };

            var game = _games.FirstOrDefault(_ => _.Id == gameId);

            if (game == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                result.Data = _mapper.Map<MonopolyGameModel>(game);
            }

            await Task.CompletedTask;
            return result;
        }

        public async Task<GenericResultModel<object>> UpdateGame(MonopolyGameModel model)
        {
            var result = new GenericResultModel<object>
            {
                Success = true
            };

            var game = _games.FirstOrDefault(_ => _.Id == model.Id);

            if (game == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                model.LastUpdateTime = DateTime.UtcNow;
                _mapper.Map(model, game);
            }

            await Task.CompletedTask;
            return result;
        }
    }
}