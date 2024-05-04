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
    } // end book controller
} // end namespace
