using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Infrastructure.Repositories;

namespace NetRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAll());
        }
    }
}
