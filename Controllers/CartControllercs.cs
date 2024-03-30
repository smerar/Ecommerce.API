using Ecommerce.API.DataModels.ResponseModels.UserResponseModel;
using Ecommerce.API.DataModels.ViewModels.CartViewModels;
using Ecommerce.API.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartControllercs : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartControllercs(ICartService cartService) { 
            _cartService = cartService;
        }

        [HttpPost]
        [Route("AddProductToCart")]
        public IActionResult addProductToCart(CartItemModel cartItem) {
            var data=_cartService.addProductToCart(cartItem);
            return Ok(data);
        
        }
        [HttpPost]
        [Route("GetCartProducts")]
        public IActionResult getCartProducts(int userId)
        {
         
            var data = _cartService.getCartProducts(userId);
            return Ok(data);

        }
        [HttpDelete]
        [Route("DeleteCartProducts")]
        public IActionResult deleteCartProducts(int userId, int productId)
        {

            var data = _cartService.deleteCartProducts(userId,productId);
            return Ok(data);

        }
    }
}
