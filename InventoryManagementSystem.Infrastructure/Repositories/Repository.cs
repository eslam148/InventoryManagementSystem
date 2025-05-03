using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.RepositoriesInterfaces;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplictionContext _context;
        public Repository(ApplictionContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            _context.Set<TEntity>().Where(e=>e.Id == id).ExecuteDeleteAsync();
        }

        public Task<TEntity> FirstOrDefuiltAsync(Expression<Func<TEntity, bool>>? predicate, bool track = false)
        {
            if (track)
            {
                return _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);

            }
            return _context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = default)
        {
            if (predicate != null)
            {
                return _context.Set<TEntity>().Where(predicate);
            }

            return _context.Set<TEntity>();   
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null,Expression<Func<TEntity, object>>[] includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
        public Task<TEntity> GetByIdAsync(int id)
        {
                return _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
