using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class ResponseDto
    {
        public string username { get; set; } = "";
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public string photo { get; set; }
        [Required]
        public string? token;
        public long userId { get; set; }
    }
}