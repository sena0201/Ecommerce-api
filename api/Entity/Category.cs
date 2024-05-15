using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class Category
{
    public long CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public long? SupplierId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Supplier? Supplier { get; set; }
}
