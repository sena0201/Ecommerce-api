using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public abstract class ResponseDto
    {
        public int page { get; set; }
        public int pageCount { get; set; }
        public int pageSize { get; set; }
    }
}