using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.AuthenticationModels;
using Models.HomeModels;

namespace DataManager.GameStorages
{
    public interface IGameCreationStorage
    {
        Task<GenericResultModel<ICollection<GameCreationModel>>> GetCreatedGames();
        Task<GenericResultModel<GameCreationModel>> CreateGame(GameCreationModel model);
        Task<GenericResultModel<object>> DeleteGame(Guid gameId);
        Task<GenericResultModel<object>> AddPlayer(Guid gameId, UserModel user);
    }
}