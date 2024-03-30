using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.API.DataModels.ViewModels.CartViewModels;
using Ecommerce.DataModels.ResponseModels;

namespace Ecommerce.API.DataModels.ResponseModels.UserResponseModel
{
    public class CartResponseModel:BaseResponseModel
    {
        public int UserId { get; set; }
        public int SubTotal { get; set; }
        public double Total { get; set; }

        public List<CartProductsModel> products { get; set; } = new List<CartProductsModel>();
    }
}
