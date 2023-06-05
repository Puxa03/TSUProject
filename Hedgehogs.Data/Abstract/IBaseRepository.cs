using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs.Data
{
    public interface IBaseRepository<T> where T : class
    {

        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(params object[] key);

        Task AddAsync(T item);


        Task<bool> Exists(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(params object[] key);

        Task UpdateAsync(T item);

        IQueryable<T> Table { get; }

        

    }
}
