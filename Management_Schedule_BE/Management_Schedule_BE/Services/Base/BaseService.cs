using Management_Schedule_BE.Repositories.Interfaces;
using Management_Schedule_BE.Services.Exceptions;
using Management_Schedule_BE.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public BaseService(IGenericRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository không được để trống");
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi khi lấy danh sách {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    throw new NotFoundException(typeof(T).Name, id);
                }
                return entity;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi khi lấy {typeof(T).Name} với mã {id}", ex);
            }
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                    throw new ArgumentNullException(nameof(expression), "Điều kiện tìm kiếm không được để trống");

                return await _repository.FindAsync(expression);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi khi tìm kiếm {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "Dữ liệu không được để trống");

                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new ServiceException($"Lỗi khi thêm mới {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi không xác định khi thêm mới {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities), "Danh sách dữ liệu không được để trống");

                await _repository.AddRangeAsync(entities);
                await _repository.SaveChangesAsync();
                return entities;
            }
            catch (DbUpdateException ex)
            {
                throw new ServiceException($"Lỗi khi thêm mới nhiều {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi không xác định khi thêm mới nhiều {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "Dữ liệu không được để trống");

                _repository.Update(entity);
                await _repository.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ServiceException($"Lỗi đồng thời khi cập nhật {typeof(T).Name}", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new ServiceException($"Lỗi khi cập nhật {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi không xác định khi cập nhật {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    throw new NotFoundException(typeof(T).Name, id);
                }

                _repository.Remove(entity);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw new ServiceException($"Lỗi khi xóa {typeof(T).Name} với mã {id}", ex);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi không xác định khi xóa {typeof(T).Name} với mã {id}", ex);
            }
        }

        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<int> ids)
        {
            try
            {
                if (ids == null || !ids.Any())
                    throw new ArgumentException("Danh sách mã không được để trống", nameof(ids));

                var entities = new List<T>();
                foreach (var id in ids)
                {
                    var entity = await _repository.GetByIdAsync(id);
                    if (entity != null)
                        entities.Add(entity);
                }

                if (!entities.Any())
                    return false;

                _repository.RemoveRange(entities);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new ServiceException($"Lỗi khi xóa nhiều {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi không xác định khi xóa nhiều {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                    throw new ArgumentNullException(nameof(expression), "Điều kiện kiểm tra không được để trống");

                return await _repository.ExistsAsync(expression);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Lỗi khi kiểm tra sự tồn tại của {typeof(T).Name}", ex);
            }
        }
    }
} 