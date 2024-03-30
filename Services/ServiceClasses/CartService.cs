using Azure;
using Ecommerce.API.Data;
using Ecommerce.API.DataModels.ResponseModels.UserResponseModel;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.API.DataModels.ViewModels.CartViewModels;
using Ecommerce.API.Services.ServiceInterfaces;
using Ecommerce.DataModels.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Services.ServiceClasses
{
    public class CartService : ICartService
    {
        public readonly EcommerceApiDbContext _context;
        public CartService(EcommerceApiDbContext context)
        {
            _context = context;
        }

       public  CartResponseModel addProductToCart(CartItemModel cartItems)
        {
            CartResponseModel response = new CartResponseModel();
            Cart _cart = new Cart();

            try
            {
               
                var cartItem = _context.Carts.Where(x => x.UserId == cartItems.UserId);
                //If there are no items in cart
                if (cartItem.ToList().Count ==0)
                {
                    
                     var productDetail = _context.Products.Where(p => p.Id == cartItems.ProductId);
                    _cart.UserId = cartItems.UserId;
                    _cart.ProductId = cartItems.ProductId;
                    _cart.Quantity = cartItems.Quantity;
                    _cart.ShipppingCarges = _context.Products.Where(x=>x.Id==cartItems.ProductId).FirstOrDefault().ShippingCharges;

                    _context.Carts.Add(_cart);
                    _context.SaveChanges();

                }
                //If there are items in cart
                else
                {
                    foreach(var cartitem in cartItem.ToList())
                    {

                        if(_context.Carts.Where(x=>x.ProductId==cartItems.ProductId).ToList().Count==0)
                        {
                            _cart.UserId = cartItems.UserId;
                            _cart.ProductId = cartItems.ProductId;
                            _cart.Quantity = cartItems.Quantity;
                            _context.Carts.Add(_cart);
                            _context.SaveChanges();
                        }
                        else
                        {
                            _cart.Quantity+=cartitem.Quantity;

                            _context.Carts.Where(x => x.UserId == cartItems.UserId && x.ProductId==cartItems.ProductId).ExecuteUpdate(b => b.SetProperty(u => u.Quantity, _cart.Quantity));
                            _context.SaveChanges();
                        }
                       
                    }
                    
                  

                 
                    
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
           response= getCartProducts(cartItems.UserId);
            return response ;
        }
   
      //  Cart not working properly
       public CartResponseModel getCartProducts(int userId)
        {
            CartResponseModel response = new CartResponseModel();
            try
            {
                List<Cart> allItemsInCart=new List<Cart>(); 
                allItemsInCart = _context.Carts.Where(x => x.UserId == userId).ToList();
                if(allItemsInCart.Count>0)
                {
                    response.UserId = userId;
                    response.SubTotal = 0;
                    foreach (var item in allItemsInCart)
                    {
                        CartProductsModel product = new CartProductsModel();
                        product.productId = (int)item.ProductId;
                        product.quantity = (int)item.Quantity;
                        var productDetails = _context.Products.Where(x => x.Id == item.ProductId).First();
                       
                        
                                product.productName = productDetails.Name;
                                product.productImage = productDetails.ImageUrl;
                                product.quantity = (int)item.Quantity;
                                product.price = productDetails.Price *(int) item.Quantity;

                                response.SubTotal += product.price;
                                response.products.Add(product);
                            

                    }
                    response.Total = response.SubTotal * 0.10 + response.SubTotal;//Adding tax to total
                    response.Status = true;
                    return response;
                }
                else
                {
                    response.Status = false;
                    return response;

                }
               
               
               
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
      

        }

        public BaseResponseModel deleteCartProducts(int userId,int productId)
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                Cart _cart = new Cart();
                var data=_context.Carts.Where(x=>x.UserId==userId && x.ProductId==productId).ToList();
                foreach(var d in data)
                {
                    _context.Carts.Remove(d);
                    _context.SaveChanges();

                }
                
               
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message=ex.Message;
            }
            response.Status=true;
            response.Message = "Deleted successfully";
            return response;

        }


    }
}
