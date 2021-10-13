using Microsoft.EntityFrameworkCore.Query;
using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Application
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        ICollection<TEntity> Collection { get; }

        Task AddAsync(TEntity entity);
        Task<PagedResults<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery queryParams, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TQuery : IPagedQuery;

        Task DeleteAsync(TKey id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(TEntity entity);
    }
   
}
