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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(long id)
        {
            var Category = await Get(id);

            if (Category == null)
                return false;

            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category?> Get(long id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
