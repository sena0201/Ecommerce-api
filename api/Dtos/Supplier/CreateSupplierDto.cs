using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Supplier
{
    public class CreateSupplierDto
    {
        [Required]
        [MaxLength(50)]
        public string? SupplierName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Address { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required, MaxLength(20)]
        public string? Hotline { get; set; }
    }
}