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
        //...................Admin Login.......................
       LoginResponseModel AdminLogin(LoginModel loginModel);

       //...................Categories...............
       CategoryModel SaveCategory(CategoryModel newCategory);
       bool DeleteCategory(int deleteId);
       bool UpdateCategory(CategoryModel updateCategory);
       List<CategoryModel> GetCategories();

        //.............................Products.............
       ProductModel SaveProduct(ProductModel newProduct);
       List<ProductModel> GetProducts();
       ProductModel GetProductById(int productId);
       public bool UpdateProductStock(int productId, int productStock);
       public bool UpdateProductPrice(int productId, int productPrice);
        public bool DeleteProduct(int productId);


    }
}
