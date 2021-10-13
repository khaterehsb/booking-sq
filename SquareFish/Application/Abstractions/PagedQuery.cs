namespace SquareFish.Application
{
    public class PagedQuery : IPagedQuery
    {
        public PagedQuery(int page, int results, string orderBy, string sortOrder)
        {
            Page = page;
            Results = results;
            OrderBy = orderBy;
            SortOrder = sortOrder;
        }

        public int Page { get; }

        public int Results { get; }

        public string OrderBy { get; }

        public string SortOrder { get; }
    }
}
