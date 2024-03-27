using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Data
{
    public class CartItems
    {
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        // Add other navigation properties as needed
    }
}
