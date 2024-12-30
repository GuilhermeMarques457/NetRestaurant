using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Infrastructure.Repositories;

namespace NetRestaurant.UI.Controllers
{
    public class DishesController : Controller
    {
        private readonly DishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishesController(DishRepository dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dishRepository.GetAll());
        }
    }
}
