using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetRestaurant.Core.Entities;
using NetRestaurant.Infrastructure.Repositories;
using System.Security.Claims;

namespace NetRestaurant.UI.Controllers
{
    [Authorize(AuthenticationSchemes = "UserCookie")]
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly UserRepository _userRepository;

        public OrderController(OrderRepository orderRepository, UserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Int64 dishId)
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = await _userRepository.Get(userId);

                var isDishAdded =  await _orderRepository.AddDishToOrder(user, dishId);

                var itemCount = await _orderRepository.GetOrderItemCount(user);

                if(isDishAdded)
                    return Json(new { success = true, itemCount });
                else
                    return Json(new { success = false, message = "You've already had this dish in your Order, Finish it or add new ones" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderCount()
        {
            var userId = Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userRepository.Get(userId);

            var itemCount = await _orderRepository.GetOrderItemCount(user);
            return Json(new { success = true, itemCount });
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userRepository.Get(userId);

            var order = await _orderRepository.GetOrderByUser(user);

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveItem(Int64 dishId, Int64 orderId)
        {
            try
            {
                await _orderRepository.RemoveItem(dishId, orderId);

                TempData["Success"] = "The operation occurred successfully";
            }
            catch (Exception)
            {
                TempData["Error"] = "The operation has failed";

            }

            return RedirectToAction(nameof(Cart));

        }

        [HttpGet]
        public async Task<IActionResult> Finish(Int64 Id)
        {
            try
            {
                var order = await _orderRepository.Get(Id);
                order.OrderStatus = Core.Enums.OrderStatus.Processing;

                await _orderRepository.Update(order);

                TempData["Success"] = "You've finished the order proccess, wait for the Chef!";
            }
            catch (Exception)
            {
                TempData["Error"] = "The operation has failed";

            }

            return RedirectToAction(nameof(Thanks));
        }

        [HttpGet]
        public async Task<IActionResult> Thanks()
        {
            return View();
        }
    }
}