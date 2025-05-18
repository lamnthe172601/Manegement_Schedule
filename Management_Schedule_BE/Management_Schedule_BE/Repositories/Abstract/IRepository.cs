using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task CommitChangeAsync();
        void Create(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetDataAsync(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetDataIncludeAsync(Expression<Func<T, bool>> expression = null, Expression<Func<T, object>> include1 = null, Expression<Func<T, object>> include2 = null, Expression<Func<T, object>> include3 = null);
        Task<T> GetObjectByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include1 = null, Expression<Func<T, object>> include2 = null, Expression<Func<T, object>> include3 = null);
        Task InsertRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
