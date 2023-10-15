using LibraryApp.Core.DTOs;
using LibraryApp.Core.Entities;
using LibraryApp.Core.Repositories;
using LibraryApp.Core.Services;
using LibraryApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IGenericRepository<Book> repository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            _bookRepository = bookRepository;
        }

        public async Task BorrowBookAsync(Book book, BorrowBookDto borrowBookDto)
        {
            book.IsInLibrary = borrowBookDto.IsInLibrary;
            book.Borrower = borrowBookDto.BorrowName;
            book.FinishDate = borrowBookDto.FinishDate;

            _bookRepository.Update(book);
            await _unitOfWork.CommitAsync();
        }
    }
}
