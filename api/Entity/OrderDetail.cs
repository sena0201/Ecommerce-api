using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class OrderDetail
{
    public long OrderDetailId { get; set; }

    public long? OrderId { get; set; }

    public long? ProductId { get; set; }

    public long? Quantity { get; set; }

    public virtual Product? Product { get; set; }
    public virtual Order? Order { get; set; }
}
