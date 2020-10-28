using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.HomeModels;
using Monopoly.GameCommunication;

namespace Monopoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly MonopolyGameCommunication _gameCommunication;
        private GameCreationModel _gameCreationModel;

        public HomeController(MonopolyGameCommunication gameCommunication)
        {
            _gameCommunication = gameCommunication;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return new ObjectResult("Hey2");
        }

        [Route("Privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return new ObjectResult("Hey");
        }
    }
}