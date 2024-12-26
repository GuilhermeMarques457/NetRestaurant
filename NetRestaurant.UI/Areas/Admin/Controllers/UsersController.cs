using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Core.Entities;
using NetRestaurant.Infrastructure.Repositories;
using NetRestaurant.UI.Areas.Admin.ViewModels;

namespace NetRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAll());
        }

        public async Task<IActionResult> Edit(Int64 id = 0)
        {
            var user = await _userRepository.Get(id);
            var userVM = new UserVM();

            if(user == null)
                return View(userVM);

            userVM = _mapper.Map<User, UserVM>(user);

            return View(userVM);
        }
    }
}
