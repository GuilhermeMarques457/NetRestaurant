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
        public Category Category { get; set; }
    }
}
