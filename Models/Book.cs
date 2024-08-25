using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters.")]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "AuthorId must be a positive integer.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "PublishedYear is required.")]
        [Range(1450, 9999, ErrorMessage = "PublishedYear must be a valid year.")]
        public int PublishedYear { get; set; }

        [Required(ErrorMessage = "ISBN is required.")]
        [RegularExpression(@"^\d{10}$|^\d{13}$", ErrorMessage = "Invalid ISBN format.")]
        public string ISBN { get; set; }
    }
}
