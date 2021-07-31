using my_books.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Maps
{
    public class PublisherMap
    {
        private Publisher publisher;

        public PublisherMap(Publisher publisher)
        {
            this.publisher = publisher;
        }

        public ExpandoObject map()
        {
            dynamic DynamicObject = new ExpandoObject();

            DynamicObject.id = this.publisher?.Id;
            DynamicObject.name = this.publisher?.Name;

            return DynamicObject;
        }
    }
    
    public class PublisherMapList
    {
        private List<Publisher> publishers;

        public PublisherMapList(List<Publisher> publishers)
        {
            this.publishers = publishers;
        }

        public List<ExpandoObject> map()
        {
            return this.publishers.Select(publisher => new PublisherMap(publisher).map()).ToList();
        }
    }
}
