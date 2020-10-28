using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DataManager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Models.AuthenticationModels;

namespace Monopoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserStorage _storage;

        public AuthorizationController(IUserStorage storage)
        {
            _storage = storage;
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return new ObjectResult(new AuthenticationModel());
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _storage.Authenticate(model);
                if (result.Success)
                {
                    await Authenticate(result.Data);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, result.Error.Message);
            }

            return new ObjectResult(model);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Authorization");
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return new ObjectResult(new RegistrationModel());
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _storage.Register(model);
                if (result.Success)
                {
                    return RedirectToAction("Login", "Authorization");
                }

                ModelState.AddModelError(string.Empty, result.Error.Message);
            }

            return new ObjectResult(model);
        }

        private async Task Authenticate(UserModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, $"{model.Role}")
            };

            var id = new ClaimsIdentity(claims,
                "AuthCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}