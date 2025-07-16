using System.ComponentModel.DataAnnotations;

namespace PlanifyAPI.Models.Commands.Users
{
    public class CreateUserCommand
    {
        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters")]
        public string Password { get; set; }

        //   [Required(ErrorMessage = "Confirm password is required")]
      //    [Compare("Password", ErrorMessage = "Passwords do not match")]
       // public string ConfirmPassword { get; set; }
    }
}
