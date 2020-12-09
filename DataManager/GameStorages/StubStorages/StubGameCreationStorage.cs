using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities.GameEntities;
using Database.Entities.UserEntity;
using Models;
using Models.AuthenticationModels;
using Models.HomeModels;

namespace DataManager.GameStorages.StubStorages
{
    public class StubGameCreationStorage : IGameCreationStorage
    {
        private readonly ICollection<GameCreation> _games;
        private readonly Mapper _mapper;

        public StubGameCreationStorage(Mapper mapper)
        {
            _mapper = mapper;

            _games = new List<GameCreation>
            {
                new GameCreation(new User(), "FirstGame"),
                new GameCreation(new User(), "SecondGame", true) {Password = "1234"},
                new GameCreation(new User(), "ThirdGame")
            };
        }

        public async Task<GenericResultModel<ICollection<GameCreationModel>>> GetCreatedGames()
        {
            var result = new GenericResultModel<ICollection<GameCreationModel>>
            {
                Success = true
            };

            if (_games.Any())
            {
                result.Data = _games.Select(_ => _mapper.Map<GameCreationModel>(_))
                                    .ToList();
            }
            else
            {
                result.Success = false;
                result.Error = new ErrorModel("No games found.");
            }

            await Task.CompletedTask;
            return result;
        }

        public async Task<GenericResultModel<GameCreationModel>> CreateGame(GameCreationModel model)
        {
            var result = new GenericResultModel<GameCreationModel>
            {
                Success = true
            };

            if (_games.Any(_ => _.Name == model.Name))
            {
                result.Success = false;
                result.Error = new ErrorModel("A game with this name has already been created.");
            }
            else
            {
                var game = _mapper.Map<GameCreation>(model);

                _games.Add(game);

                result.Data = _mapper.Map<GameCreationModel>(game);
            }

            await Task.CompletedTask;
            return result;
        }

        public async Task<GenericResultModel<object>> DeleteGame(Guid gameId)
        {
            var result = new GenericResultModel<object>
            {
                Success = true
            };

            var gameToDelete = _games.FirstOrDefault(_ => _.Id == gameId);

            if (gameToDelete == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                _games.Remove(gameToDelete);
            }

            await Task.CompletedTask;
            return result;
        }

        public async Task<GenericResultModel<object>> AddPlayer(Guid gameId, UserModel user)
        {
            var result = new GenericResultModel<object>
            {
                Success = true
            };

            var gameToUpdate = _games.FirstOrDefault(_ => _.Id == gameId);

            if (gameToUpdate == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                gameToUpdate.Players.Add(_mapper.Map<User>(user));
            }

            await Task.CompletedTask;
            return result;
        }
    }
}