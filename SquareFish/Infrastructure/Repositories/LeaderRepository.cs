using SquareFish.Application;
using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareFish.Infrastructure.Repositories
{
    public class LeaderRepository : ILeaderRepository
    {
        private readonly IGenericRepository<Leader, int> _repository;

        public LeaderRepository(IGenericRepository<Leader, int> repository)
        {
            _repository = repository;
        }
        public Task AddAsync(Leader image)
        => _repository.AddAsync(image);

        public async Task<Leader> GetAsync(int id)
        {
            var user = await _repository.GetAsync(id);

            return user;
        }
        public async Task<List<Leader>> GetAsync(Expression<Func<Leader, bool>> predicate)
        => await _repository.GetListAsync(predicate);


        public async Task DeleteAsync(int Id)
           => await _repository.DeleteAsync(Id);
        public async Task UpdateAsync(Leader entity)
            => await _repository.UpdateAsync(entity);

        public async Task<PagedResults<Leader>> BrowseAsync(Expression<Func<Leader, bool>> predicate, PagedQuery pagedQuery)
           => await _repository.BrowseAsync(predicate, pagedQuery);

        public async Task DeleteAsync(Expression<Func<Leader, bool>> predicate)
         => await _repository.DeleteAsync(predicate);
    }

}
