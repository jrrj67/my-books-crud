using Microsoft.AspNetCore.Mvc;
using my_books.Services;
using my_books.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetBooskById(int id)
        {
            var book = _booksService.GetBookById(bookId: id);
            
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book: book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(bookId: id, book: book);
            
            if(updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var book = _booksService.DeleteBookById(bookId: id);
            
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
