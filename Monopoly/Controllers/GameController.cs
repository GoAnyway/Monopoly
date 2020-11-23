using System;
using System.Threading.Tasks;
using DataManager.GameStorages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.GameCommunication;

namespace Monopoly.Controllers
{
    [Authorize]
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
            var gameId = GetGameIdFromSession();
            var result = await _gameStorage.GetGameById(gameId);

            if (result.Success)
            {
                var lastUpdateTime = $"{result.Data.LastUpdateTime}";
                HttpContext.Session.SetString("updateTime", lastUpdateTime);

                return new ObjectResult(result.Data);
            }

            return new ObjectResult(result.Error);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetGameState()
        {
            var gameId = GetGameIdFromSession();
            var result = await _gameStorage.GetGameById(gameId);
            var cachedUpdateTime = DateTime.Parse(HttpContext.Session.GetString("updateTime"));

            return result.Success && cachedUpdateTime != result.Data.LastUpdateTime
                ? new ObjectResult(result.Data)
                : new ObjectResult(result.Error);
        }

        [Route("Move")]
        [HttpPost]
        public async Task<IActionResult> MakeMove()
        {
            var gameId = GetGameIdFromSession();
            var result = await _gameStorage.GetGameById(gameId);

            if (result.Success)
            {
                await _gameCommunication.MakeMove(result.Data);
            }

            //TODO: HEYHO
            return null;
        }

        private Guid GetGameIdFromSession() => 
            Guid.Parse(HttpContext.Session.GetString("game"));
    }
}