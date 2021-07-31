using my_books.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace my_books.ViewModels
{
    public class PublisherVM
    {
        private Publisher publisher;

        public PublisherVM(Publisher publisher)
        {
            this.publisher = publisher;
        }

        public ExpandoObject map()
        {
            dynamic DynamicObject = new ExpandoObject();

            DynamicObject.Id = publisher.Id;
            DynamicObject.Name = publisher.Name; 

            return DynamicObject;
        }
    }
}
