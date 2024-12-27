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
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly CategoryRepository _categoryRepository;

        public CategoriesController(IMapper mapper, CategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAll());
        }

        public async Task<IActionResult> Edit(Int64 id = 0)
        {
            var category = await _categoryRepository.Get(id);
            var categoryVM = new CategoryVM();

            if (category == null)
                return View(categoryVM);

            categoryVM = _mapper.Map<Category, CategoryVM>(category);

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM categoryVM)
        {
            var category = _mapper.Map<CategoryVM, Category>(categoryVM);

            try
            {
                if (category.Id == 0)
                    await _categoryRepository.Create(category);
                else
                    await _categoryRepository.Update(category);

                TempData["Success"] = "The operation occurred successfully";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "The operation has failed";
                return View(categoryVM);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var isDeleted = await _categoryRepository.Delete(id);

                if (isDeleted)
                    TempData["Success"] = "The category was deleted successfully";
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
