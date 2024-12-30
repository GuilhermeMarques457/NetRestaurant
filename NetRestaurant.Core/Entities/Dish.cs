using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRestaurant.Core.Entities
{
    public class Dish
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Int64 CategoryId { get; set; }
        public Decimal Price { get; set; }
        public TimeSpan MinimunTime { get; set; }
        public TimeSpan MaximunTime { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
