using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class Size
{
    public long SizeId { get; set; }

    public string ProductId { get; set; } = null!;

    public string? Size1 { get; set; }

    public virtual Product Product { get; set; } = null!;
}
