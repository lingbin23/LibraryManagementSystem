using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();

        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(PaginationFilter paginationFilter, string? sortBy, bool isAscending)
        {
            var books = await _bookRepository.GetAllBooksAsync();

            // Sorting
            books = (sortBy, isAscending) switch
            {
                ("title", true) => books.OrderBy(b => b.Title),
                ("title", false) => books.OrderByDescending(b => b.Title),
                ("year", true) => books.OrderBy(b => b.PublishedYear),
                ("year", false) => books.OrderByDescending(b => b.PublishedYear),
                (null or "", true) => books.OrderBy(b => b.Title), // Default to sorting by Title ascending
                (null or "", false) => books.OrderByDescending(b => b.Title), 
                _ => books
            };

            // Pagination
            books = books.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                         .Take(paginationFilter.PageSize);

            return books;
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _bookRepository.GetBookByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            if (await _bookRepository.IsISBNExistsAsync(book.ISBN))
            {
                throw new InvalidOperationException("A book with the same ISBN already exists.");
            }
            if (!await _bookRepository.IsValidPublishedYearAsync(book.PublishedYear))
            {
                throw new InvalidOperationException("The published year cannot be in the future.");
            }

            // Get the current maximum ID and ensure the new ID is greater than this
            var books = await _bookRepository.GetAllBooksAsync();
            var maxId = books.Any() ? books.Max(b => b.Id) : 0;
            book.Id = maxId + 1;

            await _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            if (!await _bookRepository.IsValidPublishedYearAsync(book.PublishedYear))
            {
                throw new InvalidOperationException("The published year cannot be in the future.");
            }
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                throw new InvalidOperationException("The book does not exist.");
            }
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
