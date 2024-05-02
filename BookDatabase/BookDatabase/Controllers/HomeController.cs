using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookDatabase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } // end index action

    } // end controller
} // end namespace
