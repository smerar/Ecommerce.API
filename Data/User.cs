using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Data
{
    [Table(name: "Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userName { get; set; }

        //This means one user can have more than one shipping address.
        // Navigation property for shipping addresses
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
    }
}
