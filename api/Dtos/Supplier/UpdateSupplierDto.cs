using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Supplier
{
    public class UpdateSupplierDto
    {
        public string? SupplierName { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Hotline { get; set; }
    }
}