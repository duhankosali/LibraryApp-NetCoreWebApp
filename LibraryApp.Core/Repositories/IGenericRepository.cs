using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T,bool>> expression); // OrderBy etc. (Alfabetik sıralama için kullanacağız)
        Task AddAsync(T entity);
        void Update(T entity); // (İlgili kitabı bir kullanıcıya atarken Update kullanacağız)
    }
}
