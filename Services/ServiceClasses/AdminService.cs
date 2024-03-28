
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
    }
}
