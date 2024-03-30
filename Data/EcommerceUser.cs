using System;
using System.Collections.Generic;

namespace Ecommerce.API.Data;

public partial class EcommerceUser
{
    public int UserId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Username { get; set; }

    public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; } = new List<ShippingAddress>();
}
