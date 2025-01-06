using Microsoft.AspNetCore.Mvc.Rendering;
using NetRestaurant.Core.Entities;

namespace NetRestaurant.UI.ViewModels
{
    public class DishFilterVM
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Search {  get; set; }
        public Int64? CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<Dish> FilteredDishes { get; set; }
    }
}
