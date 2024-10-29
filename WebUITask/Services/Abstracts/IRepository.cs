using System.Linq.Expressions;

namespace WebUITask.Services.Abstracts
{
    public interface IRepository<T>where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<T> Add(T model);
    }
}
