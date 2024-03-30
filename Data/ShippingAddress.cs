using System;
using System.Collections.Generic;

namespace Ecommerce.API.Data;

public partial class ShippingAddress
{
    public int AddressId { get; set; }

    public string Aptno { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Province { get; set; }

    public string Pincode { get; set; }

    public string PhoneNumber { get; set; }

    public string CustomerName { get; set; }

    public int? UserId { get; set; }

    public int? Active { get; set; }

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual EcommerceUser User { get; set; }
}
