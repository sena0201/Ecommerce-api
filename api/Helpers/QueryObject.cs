using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public abstract class QueryObject
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 5;
        public int? pageCount { get; set; }
        public string? searchValue { get; set; }
    }
}