using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Lấy tất cả
        Task<IEnumerable<T>> GetAllAsync();
        
        // Lấy theo ID
        Task<T?> GetByIdAsync(int id);
        
        // Lấy theo điều kiện
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        
        // Thêm một entity
        Task<T> AddAsync(T entity);
        
        // Thêm nhiều entity
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        
        // Cập nhật entity
        Task UpdateAsync(T entity);
        
        // Xóa entity
        Task RemoveAsync(T entity);
        
        // Xóa nhiều entity
        Task RemoveRangeAsync(IEnumerable<T> entities);
        
        // Kiểm tra tồn tại
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        
        // Lấy số lượng
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
    }
} 