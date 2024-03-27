using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Data
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }

        // Navigation properties
        public User User { get; set; }
        // Add other navigation properties as needed
    }
}
