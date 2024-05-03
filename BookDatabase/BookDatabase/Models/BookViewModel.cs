namespace BookDatabase.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; } = null!;
        public List<Author> Authors { get; set; } = null!;
        public List<Book> Books { get; set; } = null!;
        public List<BookAuthor> BookAuthors { get; set; } = null!;
        public List<Genre> Genres { get; set; } = null!;
        public List<Status> Statuses { get; set; } = null!;
    } // end view model
} // end namespace
