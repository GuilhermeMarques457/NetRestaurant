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
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            var user = Get(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User Get(long id)
        {
            return _context.Users.First(x => x.Id == id);
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
