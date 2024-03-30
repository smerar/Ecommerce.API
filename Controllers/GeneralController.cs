using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.API.Services.ServiceClasses;
using Ecommerce.API.Services.ServiceInterfaces;
using Ecommerce.Services.Service_Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {

        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        public GeneralController(IAdminService adminService, IUserService userService,IWebHostEnvironment env)
        {
            //  _context = context;
            _adminService = adminService;
            _userService = userService;
        }
        //To get Categories
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {

            var data = _adminService.GetCategories();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var data = _adminService.GetProducts();
                if (data == null)
                {
                    var response = new
                    {

                        status = false,
                        message = "There are no products to display",
                        responseData = data,
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        status = true,
                        count = data.Count,
                        responseData = data,
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = false,
                    message = ex.Message,

                };
                return Ok(response);

            }
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var data = _adminService.GetProductById(id);
                if (data == null)
                {
                    var response = new
                    {

                        status = false,
                        message = "Product doesnt exist",
                        responseData = data,
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        status = true,
                        responseData = data,
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = false,
                    message = ex.Message,

                };
                return Ok(response);

            }

        }

        [HttpGet]
        [Route("GetProductByCategoryId")]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            var data = _userService.GetProductByCategoryId(categoryId);
            return Ok(data);
        }

    }
}
