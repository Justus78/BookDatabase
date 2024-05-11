using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Models
{
    public class Book
    {
        [Key] 
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }

        public List<Author> Authors { get; set; } = [];

        // set the one to many relationship with Genre
        [Required(ErrorMessage = "Please select a Genre.")]
        public int GenreId { get; set; }
        [ValidateNever]
        public Genre Genre { get; set; } = null!;

        //Set the one to many relationship with Status
        [Required(ErrorMessage = "Please select a Status.")]
        public int StatusId { get; set; }
        [ValidateNever]
        public Status Status { get; set; } = null!;


    } //end book model
} // end namespace
