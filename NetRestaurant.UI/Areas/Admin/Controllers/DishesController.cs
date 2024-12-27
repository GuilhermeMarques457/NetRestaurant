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
    public class DishesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DishRepository _dishRepository;
        private readonly CategoryRepository _categoryRepository;

        public DishesController(IMapper mapper, DishRepository dishRepository, CategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _dishRepository = dishRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dishRepository.GetAll());
        }

        public async Task<IActionResult> Edit(Int64 id = 0)
        {
            var dish = await _dishRepository.Get(id);
            var dishVM = new DishVM();
            
            var categories = await _categoryRepository.GetAll();
            dishVM.Categories = categories.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            if (dish == null)
                return View(dishVM);

            dishVM = _mapper.Map<Dish, DishVM>(dish);

            return View(dishVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DishVM dishVM)
        {
            var dish = _mapper.Map<DishVM, Dish>(dishVM);

            try
            {
                if (dish.Id == 0)
                    await _dishRepository.Create(dish);
                else
                    await _dishRepository.Update(dish);

                TempData["Success"] = "The operation occurred successfully";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "The operation has failed";
                return View(dishVM);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var isDeleted = await _dishRepository.Delete(id);

                if (isDeleted)
                    TempData["Success"] = "The dish was deleted successfully";
                else
                    TempData["Error"] = "An error ocorred with the operation";

            }
            catch (Exception ex)
            {
                TempData["Error"] = "The operation has failed";
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
