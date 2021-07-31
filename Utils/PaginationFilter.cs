using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Utils
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        
        public PaginationFilter(int pageNumber, int pageSize)
        {
            int pageSizeDefault = 10;

            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;

            if(pageSize < 1)
            {
                pageSize = pageSizeDefault;
            }

            this.PageSize = pageSize > pageSizeDefault ? pageSizeDefault : pageSize;
        }
    }
}
