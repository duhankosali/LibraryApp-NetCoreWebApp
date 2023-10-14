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
    }
}
