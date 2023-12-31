﻿using Doctors.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Doctors.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context) =>
            _context = context;

        public async Task AddAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetAsync(T obj)
        {
            return await _context.Set<T>().FindAsync(obj);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(filterExpression).AsTracking().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking().AsQueryable();
            if (filterExpression != null)
                query = query.Where(filterExpression);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var result = await query.SingleOrDefaultAsync();

            return result;
        }

        public async Task RemoveAsync(T obj)
        {
            var result = _context.Set<T>();

            if (result is null)
                throw new Exception("Error to find");

            result.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
