using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database;
using Database.Entities.GameEntities;
using Database.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.AuthenticationModels;
using Models.HomeModels;

namespace DataManager.GameStorages.DbStorages
{
    public class DbGameCreationStorage : IGameCreationStorage
    {
        private readonly MonopolyContext _context;
        private readonly Mapper _mapper;

        public DbGameCreationStorage(MonopolyContext context, Mapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GenericResultModel<ICollection<GameCreationModel>>> GetCreatedGames()
        {
            var result = new GenericResultModel<ICollection<GameCreationModel>>
            {
                Success = true
            };

            if (_context.CreatedGames.Any())
            {
                var games = await _context.CreatedGames.Select(_ => _mapper.Map<GameCreationModel>(_))
                                                       .ToListAsync();

                result.Data = games;
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

            if (_context.CreatedGames.Any(_ => _.Name == model.Name))
            {
                result.Success = false;
                result.Error = new ErrorModel("A game with this name has already been created.");
            }
            else
            {
                var game = _mapper.Map<GameCreation>(model);

                _context.CreatedGames.Add(game);

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

            var gameToDelete = await _context.CreatedGames.FindAsync(gameId);

            if (gameToDelete == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                _context.CreatedGames.Remove(gameToDelete);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<GenericResultModel<object>> AddPlayer(Guid gameId, UserModel user)
        {
            var result = new GenericResultModel<object>
            {
                Success = true
            };

            var gameToUpdate = await _context.CreatedGames.FindAsync(gameId);

            if (gameToUpdate == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                gameToUpdate.Players.Add(_mapper.Map<User>(user));
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}