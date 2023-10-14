using LibraryApp.Core.Entities;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _service;
        public BooksController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
