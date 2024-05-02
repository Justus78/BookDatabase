using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
    } // end model
} // end namespace
