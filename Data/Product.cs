using System;
using System.Collections.Generic;

namespace Ecommerce.API.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public int? CategoryId { get; set; }

    public string ImageUrl { get; set; }

    public int Stock { get; set; }

    public string ProDesc { get; set; }

    public int? ShippingCharges { get; set; }
}
