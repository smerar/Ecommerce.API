using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.API.DataModels.ResponseModels.AdminResponseModels;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.DataModels;
using Ecommerce.DataModels.ResponseModels;

namespace Ecommerce.Services.Service_Interfaces
{
    public interface IAdminService
    {
       LoginResponseModel AdminLogin(LoginModel loginModel);
       CategoryModel SaveCategory(CategoryModel newCategory);
       bool DeleteCategory(int deleteId);
       bool UpdateCategory(CategoryModel updateCategory);
       List<CategoryModel> GetCategories();

    }
}
