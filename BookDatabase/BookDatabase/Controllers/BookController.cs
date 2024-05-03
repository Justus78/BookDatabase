using Microsoft.AspNetCore.Mvc;

namespace BookDatabase.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } // end action
    } // end book controller
} // end namespace
