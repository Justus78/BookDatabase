using Microsoft.EntityFrameworkCore;

namespace BookDatabase.Models
{
    public class BookViewModel
    {
        private BookContext Context { get; set; }

        public BookViewModel(BookContext context) {  Context = context; }

        public Book Book { get; set; } = null!;
        public List<Author> Authors { get; set; } = null!;
        public List<Book> Books { get; set; } = null!;
        public List<BookAuthor> BookAuthors { get; set; } = null!;
        public List<Genre> Genres { get; set; } = null!;
        public List<Status> Statuses { get; set; } = null!;

        public string GetGenre(int id)
        {
            var genre = Context.Genres.Where(g => g.GenreId == id).Select(g => g.Name).FirstOrDefault();
            return genre ?? "Genre not found.";
        } // end method

        public string GetStatus(int id)
        {
            var status = Context.Statuses.Where(s => s.StatusId == id).Select(s => s.StatusName).FirstOrDefault();
            return status ?? "Status not found.";
        } // end method
    } // end view model
} // end namespace
