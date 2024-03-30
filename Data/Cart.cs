using System;
using System.Collections.Generic;

namespace Ecommerce.API.Data;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? ShipppingCarges { get; set; }
}
