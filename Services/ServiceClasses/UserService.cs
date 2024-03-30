using Ecommerce.API.Data;
using Ecommerce.API.DataModels.ResponseModels.AdminResponseModels;
using Ecommerce.API.DataModels.ResponseModels.UserResponseModel;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.API.DataModels.ViewModels.CartViewModels;
using Ecommerce.API.DataModels.ViewModels.UserViewModels;
using Ecommerce.API.Services.ServiceInterfaces;
using Ecommerce.DataModels.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Services.ServiceClasses
{
    public class UserService :IUserService
    {
        private readonly EcommerceApiDbContext _context;

        public UserService(EcommerceApiDbContext context) { _context=context; }



        public List<ProductModel> GetProductByCategoryId(int categoryId)
        {
            try
            {
                var data = _context.Products.Where(x => x.CategoryId == categoryId).ToList();
                List<ProductModel> productList = new List<ProductModel>();
                foreach (var p in data)
                {
                    ProductModel _productModel = new ProductModel();
                    _productModel.Id = p.Id;
                    _productModel.Name = p.Name;
                    _productModel.Price = p.Price;
                    _productModel.ImageUrl = p.ImageUrl;
                    _productModel.Stock = p.Stock;
                    productList.Add(_productModel);
                }
                return productList;
            }
            catch
            {
                throw;
            }

        }

        public RegistrationResponseModel Register(RegistrationModel registrationModel)
        {
            RegistrationResponseModel response = new RegistrationResponseModel();
            try
            {
                EcommerceUser ecommerceUser = new EcommerceUser();


                if (registrationModel.password != registrationModel.ConfirmPassword)
                {
                    response.Status = false;
                    response.Message = "Passwords doesnt match";
                    response.Username = "";
                    response.Email = "";
                }
                else
                {
                    var userEmail = _context.EcommerceUsers.Where(x => x.Email == registrationModel.email).ToList();
                    var userName = _context.EcommerceUsers.Where(x => x.Username == registrationModel.userName).ToList();
                    if (userEmail.Count>0)
                    {
                        response.Status = false;
                        response.Message = "Email Already registered with us!";

                    }
                    else if(userName.Count>0)
                    {
                        response.Status = false;
                        response.Message = "Username already taken !";
                    }

                    else
                    {
                       Cart cart = new Cart();
                       
                        ecommerceUser.Username = registrationModel.userName;
                        ecommerceUser.Password = registrationModel.password;
                        ecommerceUser.Email = registrationModel.email;
                      
                        var rowsAffected = _context.Add(ecommerceUser);
                        _context.SaveChanges();

                        response.Email = ecommerceUser.Email;
                        response.Status = true;
                        response.Message = "Registration Completed";
                        response.Username = ecommerceUser.Username;
                        cart.UserId = ecommerceUser.UserId;
           

                    }
                }
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Message = "Server Error ! "+ ex.Message;
                return response;
            }
            return response;

        }
 

 

    

        


     

    
    

     
    }
}
