using System.ComponentModel.DataAnnotations;

namespace NetRestaurant.UI.Areas.Admin.ViewModels
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "This field must be an email address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
