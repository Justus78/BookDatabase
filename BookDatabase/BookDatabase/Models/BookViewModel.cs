using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Models
{
    public class BookViewModel
    { 
        public Book Book { get; set; } = null!;
        [ValidateNever]
        public List<Author> Authors { get; set; } = null!;
        [ValidateNever]
        public List<Book> Books { get; set; } = null!;
        [ValidateNever]
        public List<BookAuthor> BookAuthors { get; set; } = null!;
        [ValidateNever]
        public List<Genre> Genres { get; set; } = null!;
        [ValidateNever]
        public List<Status> Statuses { get; set; } = null!;

        public List<int> SelectedAuthorIds { get; set; } = new List<int>();
        
    } // end view model
} // end namespace
