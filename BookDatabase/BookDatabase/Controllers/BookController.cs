using BookDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDatabase.Controllers
{
    public class BookController : Controller
    {
        public BookContext Context { get; set; }

        public BookController(BookContext context) { Context = context; }
        public IActionResult Index()
        {
            var model = new BookViewModel(Context)
            {
                Books = Context.Books.OrderBy(b => b.BookId).ToList(),
                Authors = Context.Authors.OrderBy(a => a.AuthorId).ToList(),
                BookAuthors = Context.BookAuthors.OrderBy(ba => ba.AuthorId).ToList(),
                Genres = Context.Genres.OrderBy(g => g.GenreId).ToList(),
                Statuses = Context.Statuses.OrderBy(s => s.StatusId).ToList(),
            };
            return View(model);
        } // end action

        [HttpGet]
        public IActionResult AddBook()
        {
            return View(new Book());
        } // end action AddBook

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            // add new book and authors to the database
            // new authors might have to be added first then their
            // author Ids can be added to the BookAuthors table.
            return View();
        } // end action AddBook
    } // end book controller
} // end namespace
