using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
