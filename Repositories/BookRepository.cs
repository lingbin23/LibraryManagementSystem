using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            // Initialize with some dummy data for demonstration purposes
            _books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", AuthorId = 1, PublishedYear = 1995, ISBN = "1234567890" },
            new Book { Id = 2, Title = "Book 2", AuthorId = 2, PublishedYear = 2012, ISBN = "0888666333" },
            new Book { Id = 3, Title = "Book 3", AuthorId = 2, PublishedYear = 2023, ISBN = "8888333311" }
        };
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_books.AsEnumerable());
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task AddBookAsync(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task UpdateBookAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.AuthorId = book.AuthorId;
                existingBook.PublishedYear = book.PublishedYear;
                existingBook.ISBN = book.ISBN;
            }
            return Task.CompletedTask;
        }

        public Task DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return Task.CompletedTask;
        }

        public Task<bool> IsISBNExistsAsync(string isbn)
        {
            var exists = _books.Any(b => b.ISBN == isbn);
            return Task.FromResult(exists);
        }

        public Task<bool> IsValidPublishedYearAsync(int publishedYear)
        {
            var valid = publishedYear <= DateTime.Now.Year;            
            return Task.FromResult(valid);
        }
    }
}
