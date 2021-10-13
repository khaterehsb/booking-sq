using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace SquareFish.Application
{
    public class PagedResults<T>: PagedResult
    {
        public List<T> Items { get; set; }
        


        public static PagedResults<TEntity> Create<TEntity>(List<TEntity> items, int page, int results, int totalPages, int count)
        {
            return new PagedResults<TEntity>()
            {
                Items = items,
                CurrentPage = page,
                PageCount = totalPages,
                PageSize = results,
                RowCount = count
            };
        }
    }
}
