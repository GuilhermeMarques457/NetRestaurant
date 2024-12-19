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
    public class DishRepository : IRepository<Dish>
    {
        private readonly ApplicationDbContext _context;

        public DishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dish> Create(Dish entity)
        {
            await _context.Dishes.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(long id)
        {
            var Dish = await Get(id);

            if (Dish == null)
                return false;

            _context.Dishes.Remove(Dish);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Dish?> Get(long id)
        {
            return await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Dish>> GetAll()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task<Dish> Update(Dish entity)
        {
            _context.Dishes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
