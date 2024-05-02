using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    } // end model
} // end namespace
