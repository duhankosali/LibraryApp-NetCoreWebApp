using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); // EF --> SaveChangeAsync
        void Commit(); // EF --> SaveChange
    }
}
