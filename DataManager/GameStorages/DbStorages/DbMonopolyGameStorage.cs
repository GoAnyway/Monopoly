using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database;
using Database.Entities.GameEntities;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.AuthenticationModels;
using Models.GameModels;
using Models.HomeModels;

namespace DataManager.GameStorages.DbStorages
{
    public class DbMonopolyGameStorage : IMonopolyGameStorage
    {
        private readonly MonopolyContext _context;
        private readonly Mapper _mapper;

        public DbMonopolyGameStorage(MonopolyContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateGame(GameCreationModel model)
        {
            var game = _mapper.Map<MonopolyGame>(model);
            game.GameBoard = new GameBoard(await _context.Cells.ToListAsync());

            _context.ActiveGames.Add(game);

            return game.Id;
        }

        public async Task<GenericResultModel<MonopolyGameModel>> GetGameById(Guid gameId)
        {
            var result = new GenericResultModel<MonopolyGameModel>
            {
                Success = true
            };

            var game = await _context.ActiveGames.FindAsync(gameId);

            if (game == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                result.Data = _mapper.Map<MonopolyGameModel>(game);
            }

            return result;
        }

        public async Task<GenericResultModel<object>> UpdateGame(MonopolyGameModel model)
        {
            var result = new GenericResultModel<object>
            {
                Success = true
            };

            var game = await _context.ActiveGames.FindAsync(model.Id);

            if (game == null)
            {
                result.Success = false;
                result.Error = new ErrorModel("Game is not found.");
            }
            else
            {
                model.LastUpdateTime = DateTime.UtcNow;
                _mapper.Map(model, game);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}