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

        public Task<Guid> CreateGame(GameCreationModel model)
        {
            return new Task<Guid>(() =>
            {
                var game = _mapper.Map<MonopolyGame>(model);

                _games.Add(game);

                return game.Id;
            });
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

        //TODO 1: Разобраться с update
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
                _games.Remove(game);
                _games.Add(_mapper.Map<MonopolyGame>(model));
            }

            await Task.CompletedTask;
            return result;
        }
    }
}