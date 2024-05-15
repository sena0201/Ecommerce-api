using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Photo;

namespace api.Dtos.Product
{
    public class ProductDto
    {
        public long ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public long? Inventory { get; set; }

        public long? CategoryId { get; set; }

        public virtual ICollection<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
    }
}