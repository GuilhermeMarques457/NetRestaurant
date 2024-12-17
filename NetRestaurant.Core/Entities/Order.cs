using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetRestaurant.Core.Enums;

namespace NetRestaurant.Core.Entities
{
    public class Order
    {
        public Order()
        {
            CreatedAt = DateTime.Now;
        }

        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
