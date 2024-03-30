
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.API.DataModels.ViewModels.UserViewModels
{
    public class RegistrationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required ")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required ")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "User name is required ")]
        public string userName { get; set; }

    }
}
