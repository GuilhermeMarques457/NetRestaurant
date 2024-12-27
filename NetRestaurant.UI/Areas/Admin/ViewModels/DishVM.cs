using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NetRestaurant.UI.Areas.Admin.ViewModels
{
    public class DishVM
    {
        public Int64 Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Description must have 20 to 1000 characters")]
        public String Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The value of Price cannot be negative")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Int64 CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

    }
}
