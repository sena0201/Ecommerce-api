using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;

namespace api.Dtos.Supplier
{
    public class SupplierDto
    {
        public long SupplierId { get; set; }

        public string? SupplierName { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Hotline { get; set; }
        public List<CategoryDto> categories { get; set; }
    }
}