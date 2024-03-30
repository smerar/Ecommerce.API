using System;
using System.Collections.Generic;

namespace Ecommerce.API.Data;

public partial class CustomerOrder
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string OrderId { get; set; }

    public string PaymentMode { get; set; }

    public int? AddressId { get; set; }

    public int? ShippingCharges { get; set; }

    public double? SubTotal { get; set; }

    public double? Total { get; set; }

    public string ShippingStatus { get; set; }

    public string CreatedOn { get; set; }

    public string UpdatedOn { get; set; }

    public virtual ShippingAddress Address { get; set; }
}
