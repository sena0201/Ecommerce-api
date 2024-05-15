using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(6, ErrorMessage = "Username must have at least 6 characters")]
        [MaxLength(20)]
        public string? UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        [MaxLength(20)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Photo { get; set; }
    }
}