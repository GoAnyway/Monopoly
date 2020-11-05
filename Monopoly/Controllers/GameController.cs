using System;
using System.Threading.Tasks;
using DataManager.GameStorages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.GameCommunication;

namespace Monopoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMonopolyGameStorage _gameStorage;
        private readonly MonopolyGameCommunication _gameCommunication;

        public GameController(IMonopolyGameStorage gameStorage, MonopolyGameCommunication gameCommunication)
        {
            _gameStorage = gameStorage;
            _gameCommunication = gameCommunication;
        }

        [Route("Start")]
        [HttpGet]
        public async Task<IActionResult> Start()
        {
            var gameId = Guid.Parse(HttpContext.Session.GetString("game"));
            var result = await _gameStorage.GetGameById(gameId);

            return result.Success 
                ? new ObjectResult(result.Data) 
                : new ObjectResult(result.Error);
        }
    }
}