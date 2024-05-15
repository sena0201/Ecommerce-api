using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class Supplier
{
    public long SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Hotline { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
