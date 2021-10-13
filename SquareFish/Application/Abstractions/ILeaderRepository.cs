using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Application
{
    public interface ILeaderRepository
    {
        Task<Leader> GetAsync(int id);
        Task AddAsync(Leader image);
        Task<List<Leader>> GetAsync(Expression<Func<Leader, bool>> predicate);
        Task UpdateAsync(Leader entity);
        Task<PagedResults<Leader>> BrowseAsync(Expression<Func<Leader, bool>> predicate, PagedQuery pagedQuery);
        Task DeleteAsync(int Id);
        Task DeleteAsync(Expression<Func<Leader, bool>> predicate);
    }
}
