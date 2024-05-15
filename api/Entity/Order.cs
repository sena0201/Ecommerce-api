using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class Order
{
    public long OrderId { get; set; }

    public long? UserId { get; set; }

    public DateOnly? OrderTime { get; set; }

    public long StatusId { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
