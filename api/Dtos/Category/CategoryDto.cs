using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;

namespace api.Dtos.Category
{
    public class CategoryDto
    {
        public long CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? Description { get; set; }

        public long? SupplierId { get; set; }
        public List<ProductDto> products { get; set; }
    }
}