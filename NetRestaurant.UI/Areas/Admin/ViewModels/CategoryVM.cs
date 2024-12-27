using System.ComponentModel.DataAnnotations;

namespace NetRestaurant.UI.Areas.Admin.ViewModels
{
    public class CategoryVM
    {
        public Int64 Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }
    }
}
