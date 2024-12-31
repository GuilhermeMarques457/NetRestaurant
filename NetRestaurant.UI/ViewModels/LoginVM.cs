using System.ComponentModel.DataAnnotations;

namespace NetRestaurant.UI.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "This field must be an email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Password { get; set; }
    }
}
