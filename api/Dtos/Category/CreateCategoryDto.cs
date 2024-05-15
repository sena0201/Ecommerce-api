using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class CreateCategoryDto
    {
        public string? CategoryName { get; set; }

        public string? Description { get; set; }

        public long? SupplierId { get; set; }
    }
}