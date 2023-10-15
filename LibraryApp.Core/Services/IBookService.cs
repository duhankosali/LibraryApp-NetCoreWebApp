using LibraryApp.Core.DTOs;
using LibraryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services
{
    public interface IBookService : IService<Book>
    {
        Task BorrowBookAsync(Book book, BorrowBookDto borrowBookDto); // (İlgili kitabı bir kullanıcıya atarken Update kullanacağız)
    }
}
