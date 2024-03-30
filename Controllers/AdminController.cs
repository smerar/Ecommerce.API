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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
      //  private readonly EcommerceApiDbContext _context;

        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService,IWebHostEnvironment env) {
        
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

        //............................PRODUCTS..........................

        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult SaveProduct(ProductModel newProduct)
        {
            try{
                var data = _adminService.SaveProduct(newProduct);
                var response = new
                {
                    status = true,
                    message = "Product Successfully Saved",
                    savedData = data,
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

      

        


        [HttpPut]
        [Route("UpdateProductPrice")]
        public IActionResult UpdateProductPrice(int id,int price)
        {
            try
            {
                var data = _adminService.UpdateProductPrice(id,price);
                if (data)
                {
                    var response = new
                    {
                        status = true,
                        message = "Updated successfully",
                        updatedData = data
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        status = false,
                        message = "The product doesnt exist ! ",
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
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

        [HttpPut]
        [Route("UpdateProductStock")]
        public IActionResult UpdateProductStock(int id, int stock)
        {
            try
            {
                var data = _adminService.UpdateProductStock(id, stock);
                if (data)
                {
                    var response = new
                    {
                        status = true,
                        message = "Updated successfully",
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        status = false,
                        message = "The product doesnt exist ! ",
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
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

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                var data = _adminService.DeleteProduct(Id);
                if(data)
                {
                    var response = new
                    {
                        status = true,
                        message = "Deleted successfully"
                    };
                    return Ok(response);
                }
                else
                {

                }
                {
                    var response = new
                    {
                        status = false,
                        message = "Error in deleting the data"
                    };
                    return Ok(response);

                }
            }
            catch(Exception ex)
            {
                var response = new
                {
                    status = false,
                    message = "Cannot delete the item"
                };
                return Ok(response);

            }
           
            
        }


    }
}
