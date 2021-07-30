using my_books.Data;
using my_books.Models;
using my_books.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            // Saving authors

            foreach( int id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id,
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(book => book.Id == bookId);
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;
                _book.PublisherId= book.PublisherId;

                _context.SaveChanges();
            }

            return _book;
        }

        public Book DeleteBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            return book;
        }
    }
}
