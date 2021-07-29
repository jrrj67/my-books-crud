using my_books.Data;
using my_books.Models;
using my_books.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Authors.FirstOrDefault(author => author.Id == authorId);
        }

        public Author UpdateAuthorById(int authorId, AuthorVM author)
        {
            var _author = _context.Authors.FirstOrDefault(a => a.Id == authorId);

            if(_author != null)
            {
                _author.FullName = author.FullName;
                
                _context.SaveChanges();
            }

            return _author;
        }

        public Author DeleteAuthorById(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == authorId);

            if(author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }

            return author;
        }
    }
}
