using my_books.Data;
using my_books.Models;
using my_books.Maps;
using my_books.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using my_books.Utils;

namespace my_books.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public List<ExpandoObject> GetAllBooks(int PageNumber, int PageSize)
        {
            var books = _context.Books
                .Include(books => books.Publisher)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return new BookMapList(books).map();
        }

        public int GetTotalBooksRecords()
        {
            return _context.Books.Count();
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
            foreach(int id in book.AuthorIds)
            {
                var authors = _context.Authors.FirstOrDefault(ba => ba.Id == id);

                if(authors != null)
                {
                    var _book_author = new Book_Author()
                    {
                        BookId = _book.Id,
                        AuthorId = id,
                    };

                    _context.Books_Authors.Add(_book_author);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Author does not exist.");
                }
            }
        }

        public ExpandoObject GetBookById(int bookId)
        {
            var book = _context.Books.Include(books => books.Publisher).FirstOrDefault(book => book.Id == bookId);
            
            if(book == null)
            {
                throw new Exception("No book found by provided Id.");
            }

            return new BookMap(book).map();
        }

        public ExpandoObject UpdateBookById(int bookId, BookVM book)
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
                _book.PublisherId = book.PublisherId;

                _context.SaveChanges();

                foreach (int id in book.AuthorIds)
                {
                    var book_Author = new Book_Author()
                    {
                        AuthorId = id,
                        BookId = _book.Id,
                    };

                    _context.Books_Authors.Add(book_Author);
                    _context.SaveChanges();
                }
            }
            else
            {
               throw new Exception("No book found by provided Id.");
            }

            return new BookMap(_book).map();
        }

        public ExpandoObject DeleteBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No book found by provided Id.");
            }

            return new BookMap(book).map();
        }
    }
}
