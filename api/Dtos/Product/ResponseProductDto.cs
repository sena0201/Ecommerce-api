using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class ResponseProductDto : ResponseDto
    {
        public List<ProductDto> products { get; set; }
    }
}