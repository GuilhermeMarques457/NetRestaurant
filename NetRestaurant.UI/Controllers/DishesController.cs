using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetRestaurant.Infrastructure.Repositories;
using NetRestaurant.UI.ViewModels;

namespace NetRestaurant.UI.Controllers
{
    public class DishesController : Controller
    {
        private readonly DishRepository _dishRepository;
        private readonly CategoryRepository _cateogoryRepository;
        private readonly IMapper _mapper;

        public DishesController(DishRepository dishRepository, IMapper mapper, CategoryRepository cateogoryRepository)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
            _cateogoryRepository = cateogoryRepository;
        }

        public async Task<IActionResult> Index(DishFilterVM filter)
        {
            var filteredDishes = await _dishRepository.GetFilteredDishes(filter.MinPrice, filter.MaxPrice, filter.CategoryId, filter.Search);
            filter.FilteredDishes = filteredDishes.ToList();
            filter.Categories = await GetCategories();

            return View(filter);
        }

        private async Task<List<SelectListItem>> GetCategories()
        {
            var categories = await _cateogoryRepository.GetAll();

            return categories.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();
        }
    }
}
