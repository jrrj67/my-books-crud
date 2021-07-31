using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Utils
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

        public PagedResponse(T Data, int pageNumber, int pageSize, string Message = null) : base(Data, Message)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = Data;
            this.Message = Message;
        }
    }
}
