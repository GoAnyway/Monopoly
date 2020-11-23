using System.Threading.Tasks;
using DataManager.GameStorages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.HomeModels;
using Monopoly.Authentication;
using Monopoly.GameCommunication;

namespace Monopoly.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        private readonly MonopolyGameCommunication _gameCommunication;
        private readonly IGameCreationStorage _gameStorage;

        public HomeController(IGameCreationStorage gameStorage, MonopolyGameCommunication gameCommunication,
            IAuthentication authentication)
        {
            _gameStorage = gameStorage;
            _gameCommunication = gameCommunication;
            _authentication = authentication;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new ObjectResult(await GetHomeModel());
        }

        [Route("Privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return new ObjectResult("Hey!");
        }

        [Route("Create")]
        [HttpGet]
        public async Task<IActionResult> CreateGame()
        {
            var user = await _authentication.GetUserByClaim(User);

            return new ObjectResult(new GameCreationModel(user, string.Empty));
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateGame(GameCreationModel gameCreationModel)
        {
            await _gameStorage.CreateGame(gameCreationModel);

            return await JoinGame(gameCreationModel);
        }

        [Route("Cancel")]
        [HttpPost]
        public async Task<IActionResult> CancelGame(GameCreationModel gameCreationModel)
        {
            await _gameStorage.DeleteGame(gameCreationModel.Id);

            return new ObjectResult(await GetHomeModel());
        }

        [Route("Join")]
        [HttpPost]
        public async Task<IActionResult> JoinGame(GameCreationModel gameCreationModel)
        {
            var user = await _authentication.GetUserByClaim(User);
            await _gameStorage.AddPlayer(gameCreationModel.Id, user);

            return new ObjectResult(await GetHomeModel());
        }

        [Route("Start")]
        [HttpPost]
        public async Task<IActionResult> StartGame(GameCreationModel gameCreationModel)
        {
            var user = await _authentication.GetUserByClaim(User);

            if (gameCreationModel.Owner.Id == user.Id)
            {
                var gameId = await _gameCommunication.CreateGameAndGetId(gameCreationModel);
                HttpContext.Session.SetString("game", $"{gameId}");

                return RedirectToAction("Start", "Game");
            }

            return new ObjectResult(await GetHomeModel());
        }

        private async Task<HomeModel> GetHomeModel()
        {
            var authorizedUser = await _authentication.GetUserByClaim(User);
            var createdGames = await _gameStorage.GetCreatedGames();
            var homeModel = new HomeModel(authorizedUser, createdGames.Data);

            return homeModel;
        }
    }
}