namespace NetRestaurant.UI.Areas.Admin.ViewModels
{
    public class UserVM
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
