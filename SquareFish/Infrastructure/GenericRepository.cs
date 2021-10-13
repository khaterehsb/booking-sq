using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SquareFish.Application;
using SquareFish.Core;
using Microsoft.EntityFrameworkCore.Query;

using System.Linq.Dynamic.Core;

namespace SquareFish.Infrastructure
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly DbContext _context;

        #region read
        private IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public async Task<PagedResults<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery queryParams,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TQuery : IPagedQuery
        {
            IQueryable<TEntity> query = GetQueryable(predicate, include);
            if (queryParams.OrderBy != null)
            {
                query = query.OrderBy(queryParams.OrderBy, queryParams.SortOrder);
            }

            query = query.Skip(queryParams.Page * queryParams.Results);

            if (queryParams.Results > 0)
            {
                query = query.Take(queryParams.Results);
            }
            var items = await query.AsNoTracking().ToListAsync();

            var count = await query.AsNoTracking().CountAsync();
            int totalPages = 0;
            if (queryParams.Results > 0)
                totalPages = Convert.ToInt32(count / queryParams.Results) + 1;
            return PagedResults<TEntity>.Create(items, queryParams.Page, queryParams.Results, totalPages, count);
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().AnyAsync(predicate);
        }

        public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }


        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        #endregion
        #region write
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
        }
        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            _context.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAsync(predicate);
            _context.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }
        #endregion
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<TEntity> Collection => new List<TEntity>();

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }
        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
