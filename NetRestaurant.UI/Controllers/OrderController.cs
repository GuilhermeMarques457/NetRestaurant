using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}