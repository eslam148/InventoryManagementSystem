using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.RepositoriesInterfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> FirstOrDefuiltAsync(Expression<Func<TEntity, bool>>? predicate,bool track = false);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = default);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate, Expression<Func<TEntity, object>>[] includes);
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
    }
   
}
