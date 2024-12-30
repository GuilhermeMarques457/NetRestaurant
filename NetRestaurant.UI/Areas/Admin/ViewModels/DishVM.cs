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

        [Required(ErrorMessage = "The field {0} is required")]
        [RegularExpression(@"^(?:[0-1]\d|2[0-3]):[0-5]\d$", ErrorMessage = "The field {0} must be in HH:MM format")]
        public TimeSpan MinimunTime { get; set; }

        [RegularExpression(@"^(?:[0-1]\d|2[0-3]):[0-5]\d$", ErrorMessage = "The field {0} must be in HH:MM format")]
        [Required(ErrorMessage = "The field {0} is required")]
        public TimeSpan MaximunTime { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public IFormFile? Image { get; set; }
        public string ImageUrl { get; set; }
    }
}
