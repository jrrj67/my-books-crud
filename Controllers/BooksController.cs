using Microsoft.AspNetCore.Mvc;
using my_books.Services;
using my_books.Utils;
using my_books.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUriService _uriService;
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService, IUriService uriService)
        {
            _booksService = booksService;
            _uriService = uriService;
        }

        [HttpGet]
        public IActionResult GetAllBooks(int PageNumber = 1, int PageSize = 10)
        {
            var route = Request.Path.Value;

            var validFilter = new PaginationFilter(PageNumber, PageSize);

            var allBooks = _booksService.GetAllBooks(validFilter.PageNumber, validFilter.PageSize);

            var totalRecords = _booksService.GetTotalBooksRecords();

            var pagedResponse = PaginationHelper.CreatePagedResponse<ExpandoObject>
                (allBooks, validFilter, totalRecords, _uriService, route);
            
            return Ok(pagedResponse);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetBooskById(int id)
        {
            try
            {
                var book = _booksService.GetBookById(bookId: id);
                return Ok(book);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            try
            {
                _booksService.AddBook(book: book);
            }
            catch(Exception exception)
            {
                return UnprocessableEntity(new Response<ExpandoObject>(new ExpandoObject(), exception.Message));
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            try
            {
                var updatedBook = _booksService.UpdateBookById(bookId: id, book: book);
                return Ok(updatedBook);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            try
            {
                var book = _booksService.DeleteBookById(bookId: id);
                return Ok(book);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
