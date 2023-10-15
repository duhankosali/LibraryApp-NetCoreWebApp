using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> Where(Expression<Func<T, bool>> expression); // OrderBy etc. (Alfabetik sıralama için kullanacağız)
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity); // (İlgili kitabı bir kullanıcıya atarken Update kullanacağız)
    }
}
