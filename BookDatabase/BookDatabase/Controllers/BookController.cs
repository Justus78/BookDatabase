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
            var model = new BookViewModel()
            {
                Books = Context.Books.OrderBy(b => b.BookId).ToList(),
                Authors = Context.Authors.OrderBy(a => a.AuthorId).ToList(),
                BookAuthors = Context.BookAuthors.OrderBy(ba => ba.AuthorId).ToList(),
                Genres = Context.Genres.OrderBy(g => g.GenreId).ToList(),
                Statuses = Context.Statuses.OrderBy(s => s.StatusId).ToList(),
            };
            return View(model);
        } // end action

        //--------------------------- Actions for Books ----------------------------
        [HttpGet]
        public IActionResult AddBook()
        {
            var model = new BookViewModel()
            {
                Book = new Book(),
                Authors = Context.Authors.OrderBy(a => a.AuthorName).ToList(),
                Genres = Context.Genres.OrderBy(g => g.Name).ToList(),
                Statuses = Context.Statuses.OrderBy (s => s.StatusName).ToList()
            };
            return View(model);
        } // end action AddBook

        [HttpPost]
        public IActionResult AddBook(BookViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                Context.Books.Add(model.Book); 
                Context.SaveChanges();

                //Add the new records to bookAuthor table
                foreach (int authorId in model.SelectedAuthorIds)
                {
                    var newBook = new BookAuthor() { BookId = model.Book.BookId, AuthorId = authorId };
                    Context.BookAuthors.Add(newBook);
                    Context.SaveChanges();
                }

                return RedirectToAction("Index", "Book");
            } 
            else
            {
                var newModel = new BookViewModel()
                {
                    Book = new Book(),
                    Authors = Context.Authors.OrderBy(a => a.AuthorName).ToList(),
                    Genres = Context.Genres.OrderBy(g => g.Name).ToList(),
                    Statuses = Context.Statuses.OrderBy(s => s.StatusName).ToList()
                };
                return View(newModel);
            }
            
            
        } // end action AddBook

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var model = new BookViewModel()
            {
                Book = Context.Books.Find(id),
                Authors = Context.Authors.OrderBy(a => a.AuthorName).ToList(),
                Genres = Context.Genres.OrderBy(g => g.Name).ToList(),
                Statuses = Context.Statuses.OrderBy(s => s.StatusName).ToList()
            };
            return View(model);
        } // end edit book action

        [HttpPost]
        public IActionResult EditBook(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                Context.Books.Update(model.Book);
                Context.SaveChanges();

                var bookAuthors = Context.BookAuthors;
                foreach(var ba in bookAuthors)
                {
                    if (ba.BookId == model.Book.BookId)
                    {
                        Context.Remove(ba);
                        Context.SaveChanges();
                    } // end if 
                } // end foreach

                //Add the new records to bookAuthor table
                foreach (int authorId in model.SelectedAuthorIds)
                {
                    var newBook = new BookAuthor() { BookId = model.Book.BookId, AuthorId = authorId };
                    Context.BookAuthors.Add(newBook);
                    Context.SaveChanges();
                }

                return RedirectToAction("Index", "Book");
            }
            else
            {
                var newModel = new BookViewModel()
                {
                    Book = model.Book,
                    Authors = Context.Authors.OrderBy(a => a.AuthorName).ToList(),
                    Genres = Context.Genres.OrderBy(g => g.Name).ToList(),
                    Statuses = Context.Statuses.OrderBy(s => s.StatusName).ToList()
                };
                return View(newModel);
            }
        }

        [HttpGet]
        public IActionResult DeleteBook(int id)
        {

            var book = Context.Books.Find(id);
            return View(book);
        } // end action delete book

        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            Context.Books.Remove(book);
            Context.SaveChanges();
            return RedirectToAction("Index", "Book");
        } // end action post delete book
        //----------------------------- End actions for Book ---------------------//

        //////////////////////////////////////////////////////////////////////////

        //----------------------------- Actions for Author -----------------------//
        public IActionResult AuthorList()
        {
            var model = Context.Authors.OrderBy(a => a.AuthorName).ToList();
            return View(model);
        } // end action AuthorList

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View(new Author());
        } // end action AddAuthor Get

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid) 
            {
                Context.Add(author);
                Context.SaveChanges();
            } else
            {
                return View(new Author());
            }            
            return RedirectToAction("AuthorList", "Book");
        } // end action AddAuthor Post

        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var author = Context.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult EditAuthor(Author author)
        {
            if (ModelState.IsValid) { 
                Context.Authors.Update(author);
                Context.SaveChanges();
                
            } else
            {
                return View(author);
            }
            return RedirectToAction("AuthorList", "Book");
        }

        [HttpGet]
        public IActionResult DeleteAuthor(int id)
        {
            var author = Context.Authors.Find(id);
            return View(author);
        } // end delete author get action

        [HttpPost] 
        public IActionResult DeleteAuthor(Author author) 
        {
            Context.Authors.Remove(author);
            Context.SaveChanges();
            return RedirectToAction("AuthorList", "Book");
        
        } // end delete author post action



    //------------------------------- End actions for Author---------------------
    } // end book controller
} // end namespace
