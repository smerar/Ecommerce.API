using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.DataModels.ViewModels.AdminViewModels
{
    public class LoginModel
    {
        public string UserKey { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Id is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
