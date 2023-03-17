using System.ComponentModel.DataAnnotations;

namespace ManagementRazorPage.Model
{
    public class Account
    {
        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
