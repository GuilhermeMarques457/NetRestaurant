using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Infrastructure.Repositories;
using NetRestaurant.UI.ViewModels;
using System.Security.Claims;

namespace NetRestaurant.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _userRepository;

        public LoginController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM login)
        {
            var user = await _userRepository.GetByEmailPassword(login.Email, login.Password);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "User")
            };

            var identiy = new ClaimsIdentity(claims, "UserCookie");
            var principal = new ClaimsPrincipal(identiy);

            await HttpContext.SignInAsync("UserCookie", principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Dishes");
        }
    }
}
