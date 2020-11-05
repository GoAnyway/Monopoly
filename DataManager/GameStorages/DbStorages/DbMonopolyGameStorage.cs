﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Database;
using Database.Entities.GameEntities;
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

            await _context.ActiveGames.AddAsync(game);

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

        //TODO 1: Разобраться с update
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
                _context.ActiveGames.Remove(game);
                _context.ActiveGames.Add(_mapper.Map<MonopolyGame>(model));
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}