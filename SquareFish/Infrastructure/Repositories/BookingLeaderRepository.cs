using SquareFish.Application;
using SquareFish.Core;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Infrastructure.Repositories
{

    public class BookingLeaderRepository : IBookingLeaderRepository
    {
        private readonly IGenericRepository<BookingLeader, int> _repository;

        public BookingLeaderRepository(IGenericRepository<BookingLeader, int> repository)
        {
            _repository = repository;
        }
        public Task AddAsync(BookingLeader image)
        => _repository.AddAsync(image);

        public async Task<BookingLeader> GetAsync(int id)
        {
            var user = await _repository.GetAsync(id);

            return user;
        }
        public async Task<BookingLeader> GetAsync(Expression<Func<BookingLeader, bool>> predicate)
        => await _repository.GetAsync(predicate);


        public async Task DeleteAsync(int Id)
           => await _repository.DeleteAsync(Id);
        public async Task UpdateAsync(BookingLeader entity)
            => await _repository.UpdateAsync(entity);

        public async Task<PagedResults<BookingLeader>> BrowseAsync(Expression<Func<BookingLeader, bool>> predicate, PagedQuery pagedQuery)
           => await _repository.BrowseAsync(predicate, pagedQuery);

        public async Task DeleteAsync(Expression<Func<BookingLeader, bool>> predicate)
         => await _repository.DeleteAsync(predicate);
    }

}
