using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class ResponseCategoryDto : ResponseDto
    {
        public List<CategoryDto> categories { get; set; }
    }
}