using LibraryApp.Core.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Web.Models
{
    public class LibraryPageViewModel
    {
        public List<BookDto> Books { get; set; } // Get Library
        public BorrowBookDto BorrowBook { get; set; } // Borrow Method
        public CreateBookDto CreateBook { get; set; }
    }
}
