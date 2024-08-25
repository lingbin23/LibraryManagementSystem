using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] PaginationFilter paginationFilter, [FromQuery] string? sortBy, bool isAscending = true)
        {
            var books = await _bookService.GetBooksAsync(paginationFilter, sortBy, isAscending);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookCreateUpdateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                PublishedYear = bookDto.PublishedYear,
                ISBN = bookDto.ISBN
            };


            try
            {
                await _bookService.AddBookAsync(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookCreateUpdateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = new Book
            {
                Id = id,
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                PublishedYear = bookDto.PublishedYear,
                ISBN = bookDto.ISBN
            };

            try
            {
                await _bookService.UpdateBookAsync(book);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
    }
}
