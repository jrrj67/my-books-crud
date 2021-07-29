using Microsoft.AspNetCore.Mvc;
using my_books.Services;
using my_books.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorsService.GetAllAuthors();
            return Ok(allAuthors);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorsService.GetAuthorById(authorId: id);
            
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author: author);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorVM author)
        {
            var updatedAuthor = _authorsService.UpdateAuthorById(authorId: id, author: author);
            
            if(updatedAuthor == null)
            {
                return NotFound();
            }

            return Ok(updatedAuthor);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            var author = _authorsService.DeleteAuthorById(authorId: id);
            
            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
