using my_books.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Maps
{
    public class BookMap
    {
        private Book book;

        public BookMap(Book book)
        {
            this.book = book;
        }

        public ExpandoObject map()
        {
            dynamic DynamicObject = new ExpandoObject();

            DynamicObject.id = this.book.Id;
            DynamicObject.title = this.book.Title;
            DynamicObject.description = this.book.Description;
            DynamicObject.is_read = this.book.IsRead;
            DynamicObject.cover_url = this.book.CoverUrl;
            DynamicObject.rate = this.book.Rate;
            DynamicObject.genre = this.book.Genre;
            DynamicObject.publisher = new PublisherMap(this.book.Publisher).map();
            //DynamicObject.book_authors = this.book.Book_Authors;

            return DynamicObject;
        }
    }
    
    public class BookMapList
    {
        private List<Book> books;

        public BookMapList(List<Book> books)
        {
            this.books = books;
        }

        public List<ExpandoObject> map()
        {
            return this.books.Select(book => new BookMap(book).map()).ToList();
        }
    }
}
