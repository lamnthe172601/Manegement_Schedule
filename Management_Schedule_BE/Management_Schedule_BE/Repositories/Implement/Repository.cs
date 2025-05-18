using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Management_Schedule_BE.Data;
using Management_Schedule_BE.Repositories.Abstract;

namespace Management_Schedule_BE.Repositories.Implement
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<Repository<T>> _logger;
        private IDbContextTransaction _transaction;

        public Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Update(T entity)
        {
            try
            {
                EntityEntry entry = _context.Entry<T>(entity);
                entry.State = EntityState.Modified;
                _logger.LogInformation($"Updated entity of type {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating entity of type {typeof(T).Name}");
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                EntityEntry entry = _context.Entry<T>(entity);
                entry.State = EntityState.Deleted;
                _logger.LogInformation($"Deleted entity of type {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting entity of type {typeof(T).Name}");
                throw;
            }
        }

        public void Create(T entity)
        {
            try
            {
                EntityEntry entry = _context.Entry<T>(entity);
                entry.State = EntityState.Added;
                _logger.LogInformation($"Created entity of type {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating entity of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                _logger.LogInformation($"Inserted {entities.Count()} entities of type {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inserting range of entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task CommitChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Committed changes for entities of type {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error committing changes for entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting entity of type {typeof(T).Name} with id {id}");
                throw;
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _context.Set<T>().AnyAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error checking existence of entity of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null)
        {
            try
            {
                if (expression == null)
                    return await _context.Set<T>().CountAsync();
                return await _context.Set<T>().CountAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error counting entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (expression != null)
                    query = query.Where(expression);

                return await query.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting paged entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task BeginTransactionAsync()
        {
            try
            {
                _transaction = await _context.Database.BeginTransactionAsync();
                _logger.LogInformation("Started database transaction");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting database transaction");
                throw;
            }
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    _logger.LogInformation("Committed database transaction");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error committing database transaction");
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                    _logger.LogInformation("Rolled back database transaction");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rolling back database transaction");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetDataIncludeAsync(Expression<Func<T, bool>> expression = null, Expression<Func<T, object>> include1 = null, Expression<Func<T, object>> include2 = null, Expression<Func<T, object>> include3 = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (expression != null)
                    query = query.Where(expression);
                if (include1 != null)
                    query = query.Include(include1);
                if (include2 != null)
                    query = query.Include(include2);
                if (include3 != null)
                    query = query.Include(include3);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting included entities of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<T> GetObjectByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include1 = null, Expression<Func<T, object>> include2 = null, Expression<Func<T, object>> include3 = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (expression != null)
                    query = query.Where(expression);
                if (include1 != null)
                    query = query.Include(include1);
                if (include2 != null)
                    query = query.Include(include2);
                if (include3 != null)
                    query = query.Include(include3);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting object by condition of type {typeof(T).Name}");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetDataAsync(Expression<Func<T, bool>> expression = null)
        {
            try
            {
                if (expression == null)
                    return await _context.Set<T>().ToListAsync();
                return await _context.Set<T>().Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting data of type {typeof(T).Name}");
                throw;
            }
        }
    }
}
