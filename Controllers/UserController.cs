using Ecommerce.API.DataModels.ViewModels.UserViewModels;
using Ecommerce.API.Services.ServiceClasses;
using Ecommerce.API.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
     private readonly IUserService _userService;

       public UserController(IUserService userService)
        {
            _userService = userService;
        }
      
        /// <summary>
        /// Registration of Users.
        /// It checks whether passwords match or not.Only if matches it does the rest of the processing.Also it checks whether the email and user exists if it already exists it stops registration process and return status as false and appropriate message.
        /// </summary>
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegistrationModel registrationData)
        {
            var data = _userService.Register(registrationData);
            return Ok(data);

        }

       
        

    }
}
