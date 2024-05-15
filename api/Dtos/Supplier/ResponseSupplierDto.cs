using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entity;

namespace api.Dtos.Supplier
{
    public class ResponseSupplierDto : ResponseDto
    {
        public List<SupplierDto> suppliers { get; set; }
    }
}