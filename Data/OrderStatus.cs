using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Data
{
    public class OrderStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
