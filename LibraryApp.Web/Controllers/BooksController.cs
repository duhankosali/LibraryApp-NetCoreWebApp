using AutoMapper;
using LibraryApp.Core.DTOs;
using LibraryApp.Core.Entities;
using LibraryApp.Core.Services;
using LibraryApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    public class BooksController : Controller
    {
        // dependency injection
        private readonly IBookService _services;
        private readonly IMapper _autoMapper; // automapper
        private readonly IWebHostEnvironment _environment; // for save files.
        public BooksController(IBookService services, IMapper autoMapper, IWebHostEnvironment environment)
        {
            _services = services;
            _autoMapper = autoMapper;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            LibraryPageViewModel model = new();

            var books = await _services.GetAllAsync(orderBy: query => query.OrderBy(book => book.Name));
            var booksDto = _autoMapper.Map<List<BookDto>>(books.ToList()); // mapping entity to dto

            // model
            model.Books = booksDto;
            model.BorrowBook = new();
            model.CreateBook = new();

            return View(model);  
        }

        // Add new book method
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto createBook, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                createBook.FilePath = $"{Guid.NewGuid()}_{photo.FileName}";
                var path = Path.Combine(_environment.WebRootPath, "books", createBook.FilePath);

                // Dosyayı belirtilen yola kaydetme
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }
            }

            var book = _autoMapper.Map<Book>(createBook); // mapping entity to dto
            await _services.AddAsync(book);
            return RedirectToAction("Index");
        }

        // Borrow book method
        public async Task<IActionResult> Borrow(BorrowBookDto borrowBook, int bookId)
        {
            var book = await _services.GetByIdAsync(bookId);
            await _services.BorrowBookAsync(book, borrowBook);
            return RedirectToAction("Index");
        }
    }
}
