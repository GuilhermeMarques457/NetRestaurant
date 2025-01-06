using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Core.Enums;
using NetRestaurant.Infrastructure.Repositories;

namespace NetRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class OrdersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly OrderRepository _orderRepository;

        public OrdersController(IMapper mapper, OrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _orderRepository.GetAll());
        }

        public async Task<IActionResult> Details(Int64 Id)
        {
            return View(await _orderRepository.Get(Id));
        }

        public async Task<IActionResult> SetStatus(Int64 Id, int status)
        {
            var order = await _orderRepository.Get(Id);
            order.OrderStatus = Enum.Parse<OrderStatus>(status.ToString());

            await _orderRepository.Update(order);

            return RedirectToAction(nameof(Details), new { Id = Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var isDeleted = await _orderRepository.Delete(id);

                if (isDeleted)
                    TempData["Success"] = "The order was deleted successfully";
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
