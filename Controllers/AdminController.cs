using Ecommerce.API.Data;
using Ecommerce.Services.Service_Classes;
using Ecommerce.Services.Service_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Services.Service_Classes;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.DataModels.ResponseModels;
using NuGet.Protocol;
using Azure;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
      //  private readonly EcommerceApiDbContext _context;

        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService) {
        
          //  _context = context;
            _adminService = adminService;   
        }

        //.................................................LOGIN................................................

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(LoginModel loginModel)
        {
            var data=_adminService.AdminLogin(loginModel);
            return Ok(data);

        }

        //......................................................CATEGORY........................................
        //To save category
        [HttpPost]
        [Route("SaveCategory")]
        public IActionResult SaveCategory(CategoryModel newCategory)
        {
          
            try
            {
               var data = _adminService.SaveCategory(newCategory);
               var  response = new {
                  status = true,
                  message="Successfully Saved",
                  savedData=data,
                };
                return Ok(response);

            }
            catch(Exception ex) {

                var response = new
                {
                    status = false,
                    message = ex.Message
                };
                return Ok(response);

             }
        }
        //To get Categories
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {

            var data = _adminService.GetCategories();
            return Ok(data);
        }
        //To Delete Category
        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int deleteId)
        {
            try
            {
                var data = _adminService.DeleteCategory(deleteId);
                if (data)
                {
                    var response = new
                    {

                        status = true,
                        message = "Successfully Deleted the record"

                    };
                    return Ok(response);

                }
                else
                {
                    var response = new
                    {

                        status = false,
                        message = "The Category doesnt exist ! "

                    };
                    return Ok(response);
                }

            }
            catch (Exception Ex)
            {
                var response = new
                {
                    status = false,
                    message = "Error in deleting the category",
                    errorMessage = Ex.Message,
                };
                return Ok(response);
            }

           

            
        }
        //To update category
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(CategoryModel updateModel)
        {
            try
            {
                var data=_adminService.UpdateCategory(updateModel);
                if (data)
                {
                    var response = new
                    {
                        status = true,
                        message = "Updated successfully",
                        updatedData = updateModel
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new { 
                        status = false ,
                        message="The category doesnt exist ! ",
                    };
                    return Ok(response);
                }

            }
            catch(Exception ex)
            {
                var response = new
                {
                    status = false,
                    message = "Error in updating",
                    errorMessage = ex.Message,
                };
                return Ok(Response);
            }

        }

    }
}
