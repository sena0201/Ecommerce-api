using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class Product
{
    public long ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public long? Inventory { get; set; }

    public long? CategoryId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
