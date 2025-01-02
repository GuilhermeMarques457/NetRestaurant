using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Infrastructure.Repositories;
using NetRestaurant.UI.ViewModels;
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
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM login)
        {
            var user = await _userRepository.GetByEmailPassword(login.Email, login.Password);
            if (user == null || !user.IsAdmin)
            {
                TempData["Error"] = "User does not exists or is not allowed";
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var identiy = new ClaimsIdentity(claims, "AdminCookie");
            var principal = new ClaimsPrincipal(identiy);

            await HttpContext.SignInAsync("AdminCookie", principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
