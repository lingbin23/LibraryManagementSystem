using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<bool> IsISBNExistsAsync(string isbn, int? id);
        Task<bool> IsValidPublishedYearAsync(int publishedYear);
    }
}
