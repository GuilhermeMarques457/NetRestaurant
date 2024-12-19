using Microsoft.EntityFrameworkCore;
using NetRestaurant.Core.Entities;
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
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
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
    }
}
