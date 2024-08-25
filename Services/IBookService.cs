using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
        //IEnumerable<Book> GetAllBooks(int pageNumber, int pageSize, string sortBy, bool isAscending);
        Task<IEnumerable<Book>> GetBooksAsync(PaginationFilter paginationFilter, string? sortBy, bool isAscending);

        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
