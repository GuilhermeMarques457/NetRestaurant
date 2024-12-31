using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Core.Entities;
using NetRestaurant.Infrastructure.Repositories;
using NetRestaurant.UI.ViewModels;
using System.Security.Claims;

namespace NetRestaurant.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM login)
        {
            var user = await _userRepository.GetByEmailPassword(login.Email, login.Password);

            await Authenticate(user);

            return RedirectToAction("Index", "Home");
        }

      

        [HttpPost]
        public async Task<IActionResult> Register(UserVM userVM)
        {
            var user = _mapper.Map<UserVM, User>(userVM);

            try
            {
                if (user.Id == 0)
                    await _userRepository.Create(user);
                else
                    await _userRepository.Update(user);

                await Authenticate(user);

                TempData["Success"] = "The operation occurred successfully";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "The operation has failed";
                return View(userVM);
            }

            return RedirectToAction("Index", "Dishes");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Dishes");
        }
        private async Task Authenticate(User? user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "User")
            };

            var identiy = new ClaimsIdentity(claims, "UserCookie");
            var principal = new ClaimsPrincipal(identiy);

            await HttpContext.SignInAsync("UserCookie", principal);
        }
    }
}
