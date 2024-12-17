using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRestaurant.Core.Entities
{
    public class Category
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
