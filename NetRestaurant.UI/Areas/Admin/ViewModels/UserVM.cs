using System.ComponentModel.DataAnnotations;

namespace NetRestaurant.UI.Areas.Admin.ViewModels
{
    public class UserVM
    {
        public Int64 Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(8, ErrorMessage = "Password must have at leat 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Boolean IsAdmin { get; set; }
    }
}
