using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Infrastructure.Repositories;
using System.Security.Claims;

namespace NetRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly UserRepository _userRepository;

        public LoginController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userRepository.GetByUsernamePassword(username, password);
            if (user == null || !user.IsAdmin)
            {
                ViewBag.Erros = "User does not exists or is not allowed";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var identiy = new ClaimsIdentity(claims, "AdminCookie");
            var principal = new ClaimsPrincipal(identiy);

            await HttpContext.SignInAsync("AdminCookie", principal);

            return RedirectToAction("Index", "Home");
        }
    }
}
