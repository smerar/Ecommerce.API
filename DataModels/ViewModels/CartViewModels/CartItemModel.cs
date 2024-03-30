using Microsoft.Identity.Client;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
namespace Ecommerce.API.DataModels.ViewModels.CartViewModels
{
    public class CartItemModel
    {
        public int UserId { get; set; }
       public int ProductId { get; set; }
        public int Quantity { get; set; }
     
 

        

       

    }
}
