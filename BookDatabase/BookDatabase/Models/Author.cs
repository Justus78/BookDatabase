using System.ComponentModel.DataAnnotations;
namespace BookDatabase.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = [];
    } // end model
} // end namespace
