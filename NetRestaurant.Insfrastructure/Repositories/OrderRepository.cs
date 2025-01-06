using Microsoft.EntityFrameworkCore;
using NetRestaurant.Core.Entities;
using NetRestaurant.Core.Enums;
using NetRestaurant.Core.Interfaces;
using NetRestaurant.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRestaurant.Infrastructure.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(long id)
        {
            var Order = await Get(id);

            if (Order == null)
                return false;

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order?> Get(long id)
        {
            return await _context.Orders
                .Include(x => x.Dishes)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> Update(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Boolean> AddDishToOrder(User user, long dishId)
        {
            var userOrder = await _context.Orders
                .Include(x => x.Dishes)
                .FirstOrDefaultAsync(x => x.User == user && x.OrderStatus == OrderStatus.Pending);

            if (userOrder == null)
            {
                userOrder = new Order { User = user, OrderStatus = OrderStatus.Pending };
                await _context.Orders.AddAsync(userOrder);
            }

            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);

            if (dish == null)
                throw new Exception("Dish not found");

            if(userOrder.Dishes.Contains(dish)) 
                return false;

            userOrder.Dishes.Add(dish);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetOrderItemCount(User user)
        {
            var userOrder = await _context.Orders
               .Include(x => x.Dishes)
               .FirstOrDefaultAsync(x => x.User == user && x.OrderStatus == OrderStatus.Pending);

            return userOrder == null ? 0 : userOrder.Dishes.Count();
        }

        public async Task<Order> GetOrderByUser(User user)
        {
            var userOrder = await _context.Orders
              .Include(x => x.Dishes)
              .ThenInclude(d => d.Category)
              .FirstOrDefaultAsync(x => x.User == user && x.OrderStatus == OrderStatus.Pending);

            return userOrder;
        }

        public async Task<List<Order>> GetListOrderByUser(User user)
        {
            var userOrder = await _context.Orders
              .Include(x => x.Dishes)
              .ThenInclude(d => d.Category)
              .Where(x => x.User == user)
              .ToListAsync();

            return userOrder;
        }

        public async Task<Boolean> RemoveItem(Int64 dishId, Int64 orderId)
        {
            var order = await _context.Orders
                .Include(x => x.Dishes)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);

            order.Dishes.Remove(dish);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
