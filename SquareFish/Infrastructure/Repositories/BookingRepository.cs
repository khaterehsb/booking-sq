using Microsoft.EntityFrameworkCore.Query;
using SquareFish.Application;
using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IGenericRepository<Booking, int> _repository;

        public BookingRepository(IGenericRepository<Booking, int> repository)
        {
            _repository = repository;
        }
        public Task AddAsync(Booking image)
        => _repository.AddAsync(image);

        public async Task<Booking> GetAsync(int id)
        {
            var user = await _repository.GetAsync(id);

            return user;
        }
        public async Task<Booking> GetAsync(Expression<Func<Booking, bool>> predicate)
        => await _repository.GetAsync(predicate);


        public async Task DeleteAsync(int Id)
           => await _repository.DeleteAsync(Id);
        public async Task UpdateAsync(Booking entity)
            => await _repository.UpdateAsync(entity);

        public async Task<PagedResults<Booking>> BrowseAsync(Expression<Func<Booking, bool>> predicate, PagedQuery pagedQuery, Func<IQueryable<Booking>, IIncludableQueryable<Booking, object>> include = null)
           => await _repository.BrowseAsync(predicate, pagedQuery, include);
    }
    
}
