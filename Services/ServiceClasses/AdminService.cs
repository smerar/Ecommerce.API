
using Ecommerce.API.Data;
using Ecommerce.DataModels.ResponseModels;
using Ecommerce.Services.Service_Interfaces;
using System.Text.Json;
using Newtonsoft.Json;
using Ecommerce.API.DataModels.ResponseModels.AdminResponseModels;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Ecommerce.Services.Service_Classes
{

    public class AdminService : IAdminService
    {
        private readonly EcommerceApiDbContext _context;
        public AdminService(EcommerceApiDbContext context)
        {
            _context = context;
        }

        //For admin login
        public LoginResponseModel AdminLogin(LoginModel loginModel)
        
        {
            LoginResponseModel loginResponse=new LoginResponseModel();
            try
            {
                var userData = _context.AdminInfos.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password).FirstOrDefault();


                if (userData != null)
                {
                    if (userData.Password == loginModel.Password)
                    {
                        loginResponse.Password=userData.Password;
                        loginResponse.Email=loginModel.Email;
                        loginResponse.Status = true;
                        loginResponse.Message = "Login Successfull!";
                    }
                    else
                    {
                        loginResponse.Status = false;
                        loginResponse.Message = "Incorrect password !";
                    }
                }
                else
                {
                    loginResponse.Status = false;
                    loginResponse.Message = "Email not registered with us ! ";
                }
                return loginResponse;
            }
            catch(Exception ex)
            {
              loginResponse.Status=false;
                loginResponse.Message = ex.Message;
                return loginResponse;
            }            
           
          
        }
        
        //.........................................Category............................................
        public CategoryModel SaveCategory(CategoryModel newCategory)
        {
            try
            {
                Category _category = new Category();
                _category.Name = newCategory.Name;
                
                _context.Add(_category);
                _context.SaveChanges();
                return newCategory;
            }
            catch(Exception ex)
            {
                throw;
            }
           
        } 
        public List<CategoryModel> GetCategories()
        {
            var data = _context.Categories.ToList();
            List<CategoryModel> _categoryList = new List<CategoryModel>();
            foreach (var category in data)
            {
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.Id = category.Id;
                categoryModel.Name = category.Name;
                _categoryList.Add(categoryModel);
            }
            return _categoryList;
        }
        public bool DeleteCategory(int deleteId)
        {
            try
            {
                bool flag = false;
                var category = _context.Categories.Where(x => x.Id == deleteId).FirstOrDefault();
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    flag = true;
                }
                return flag;
            }
            catch 
            {
                throw;
            }
     
        }
        public bool UpdateCategory(CategoryModel updateCategory) 
        {
            try
            {
                bool flag = false;
                var category = _context.Categories.Where(x => x.Id == updateCategory.Id).FirstOrDefault();
                if (category != null)
                {
                    category.Name = updateCategory.Name;
                    _context.Categories.Update(category);
                    _context.SaveChanges();
                    flag = true;
                }
                return flag;
            }
            catch {

                throw;
            }
          
          

        }
        //........................................Products........................................

        public ProductModel SaveProduct(ProductModel newProduct) //To save the product
        {
            try
            {
                Product _product = new Product();
                _product.Name = newProduct.Name;
                _product.Price = newProduct.Price;
                _product.Stock=newProduct.Stock;
                _product.ImageUrl = newProduct.ImageUrl;
                _product.CategoryId = newProduct.CategoryId;
                _context.Add(_product);
                _context.SaveChanges();
                return newProduct;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ProductModel> GetProducts() //To list all the products
        {
            try
            {
        
                var data = _context.Products.ToList();
                List<ProductModel> _productList = new List<ProductModel>();
                foreach (var product in data)
                {
                    ProductModel productModel = new ProductModel();
                    var category = _context.Categories.Where(x => x.Id == product.CategoryId).First();
                    if(category != null)
                    {
                        productModel.CategoryName = category.Name;
                    }
                    productModel.Name = product.Name;
                    productModel.Id=product.Id;
                    productModel.CategoryId = product.CategoryId;
                    productModel.Price= product.Price;
                    productModel.Stock = product.Stock;
                    productModel.ImageUrl= product.ImageUrl;
                    _productList.Add( productModel );
                  
                }
                return _productList;

            }
            catch
            {
                throw;
            }
        }
        public ProductModel GetProductById(int productId)//To list product by id
        {
            try
            {
                ProductModel productModel = new ProductModel();
                var productFromDb = _context.Products.Where(x => x.Id == productId).First();
                var category=_context.Categories.Where(x => x.Id==productFromDb.Id).FirstOrDefault();
                if(productFromDb!=null)
                {
                    productModel.Id = productFromDb.Id;
                    productModel.CategoryId = productFromDb.CategoryId;
                    productModel.CategoryName = category.Name;
                    productModel.Name = productFromDb.Name;
                    productModel.Price = productFromDb.Price;
                    productModel.Stock = productFromDb.Stock;
                    productModel.ImageUrl = productFromDb.ImageUrl;
                }
            
                return productModel;
            }
            catch(SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateProductPrice(int productId,int productPrice)//To Update price of the product
        {
            try
            {
                bool flag = false;
                var product = _context.Products.Where(x => x.Id == productId).FirstOrDefault();
                if (product != null)
                {
                    product.Price = productPrice;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    flag = true;
                }
                return flag;
            }
            catch
            {

                throw;
            }
        }

        public bool UpdateProductStock(int productId, int productStock)//To Update the stock 
        {
            try
            {
                bool flag = false;
                var product = _context.Products.Where(x => x.Id == productId).FirstOrDefault();
                if (product != null)
                {
                    product.Stock = productStock;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    flag = true;
                }
                return flag;
            }
            catch
            {
                throw;
            }

        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                bool flag = false;
                var product = _context.Products.Where(x => x.Id == productId).First();
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    flag = true;

                }
                return flag;
            }
            catch
            {
                throw;
            }

        }
    }

}
