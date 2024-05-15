using System;
using System.Collections.Generic;

namespace api.Entity;

public partial class Photo
{
    public long PhotoId { get; set; }

    public long? ProductId { get; set; }

    public string? Url { get; set; }

    public virtual Product? Product { get; set; }
}
