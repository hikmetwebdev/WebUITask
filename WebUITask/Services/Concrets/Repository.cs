using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebUITask.Services.Abstracts;

namespace WebUITask.Services.Concrets
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;
        protected Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _table.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _table.ToList();
            }
            var models = _table.Where(predicate).ToList();
            return models;
        }
    }
}
