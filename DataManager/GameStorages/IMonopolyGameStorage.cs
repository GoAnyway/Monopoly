using System;
using System.Threading.Tasks;
using Models;
using Models.GameModels;
using Models.HomeModels;

namespace DataManager.GameStorages
{
    public interface IMonopolyGameStorage
    {
        Task<Guid> CreateGame(GameCreationModel model);
        Task<GenericResultModel<MonopolyGameModel>> GetGameById(Guid gameId);
        Task<GenericResultModel<object>> UpdateGame(MonopolyGameModel model);
    }
}