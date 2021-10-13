using Microsoft.EntityFrameworkCore.Query;
using SquareFish.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Application
{
    public interface IBookingRepository
    {
        Task<Booking> GetAsync(int id);
        Task AddAsync(Booking booking);
        Task<Booking> GetAsync(Expression<Func<Booking, bool>> predicate);
        Task UpdateAsync(Booking entity);
        Task<PagedResults<Booking>> BrowseAsync(Expression<Func<Booking, bool>> predicate, PagedQuery pagedQuery, Func<IQueryable<Booking>, IIncludableQueryable<Booking, object>> include = null);
        Task DeleteAsync(int Id);
    }
}
