using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Utils
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        
        public Response(T Data, string Message = null)
        {
            this.Data = Data;
            this.Message = Message;
        }
    }
}
