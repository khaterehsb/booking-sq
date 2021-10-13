using SquareFish.Core;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Application
{
    public interface IBookingLeaderRepository
    {
        Task<BookingLeader> GetAsync(int id);
        Task AddAsync(BookingLeader image);
        Task<BookingLeader> GetAsync(Expression<Func<BookingLeader, bool>> predicate);
        Task UpdateAsync(BookingLeader entity);
        Task<PagedResults<BookingLeader>> BrowseAsync(Expression<Func<BookingLeader, bool>> predicate, PagedQuery pagedQuery);
        Task DeleteAsync(int Id);
        Task DeleteAsync(Expression<Func<BookingLeader, bool>> predicate);
    }
}
