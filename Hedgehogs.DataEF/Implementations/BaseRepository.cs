using Hedgehogs.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs.DataEF
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        public IQueryable<T> Table { get => _dbSet; }


        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetAsync(params object[] key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task DeleteAsync(params object[] key)
        {
            var entityToRemove = await GetAsync(key);
            _dbSet.Remove(entityToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
