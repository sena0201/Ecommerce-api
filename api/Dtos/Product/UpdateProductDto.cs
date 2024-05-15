using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class UpdateProductDto
    {
        public string? ProductName { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public long? Inventory { get; set; }

        public long? CategoryId { get; set; }
    }
}