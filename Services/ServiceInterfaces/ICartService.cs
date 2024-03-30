using Ecommerce.API.DataModels.ResponseModels.UserResponseModel;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.API.DataModels.ViewModels.CartViewModels;
using Ecommerce.DataModels.ResponseModels;

namespace Ecommerce.API.Services.ServiceInterfaces
{
    public interface ICartService
    {
        public CartResponseModel addProductToCart(CartItemModel cartItems);
        public CartResponseModel getCartProducts(int userId);
        public BaseResponseModel deleteCartProducts(int userId, int productId);
    }
}
