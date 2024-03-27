using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Data
{
    public class ShippingAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public string AptNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }


        // Foriegn key
        public int UserId { get; set; }
        //Navigation property
        public User User { get; set; }
        // Add other navigation properties as needed
    }
}
