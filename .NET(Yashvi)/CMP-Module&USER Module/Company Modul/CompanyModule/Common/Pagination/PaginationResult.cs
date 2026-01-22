using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Common.Pagination
{
    public class PaginationResult<T>
    {
        public IList<T> DataResult { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

        public PaginationResult(IList<T> data, int totalRecords, int pageNumber, int pageSize)
        {
            DataResult = data;
            TotalRecords = totalRecords;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public static async Task<PaginationResult<TResult>> CreateAsync<TSource, TResult>(
            IQueryable<TSource> source,
            int pageNumber,
            int pageSize,
            Func<TSource, TResult> mapper)
        {
            var totalRecords = await source.CountAsync();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mappedItems = items.Select(mapper).ToList();
            return new PaginationResult<TResult>(mappedItems, totalRecords, pageNumber, pageSize);
        }

        public static async Task<PaginationResult<T>> CreateAsync<TSource>(
            IQueryable<TSource> source,
            int pageNumber,
            int pageSize,
            Func<TSource, T> mapper)
        {
            var totalRecords = await source.CountAsync();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mappedItems = items.Select(mapper).ToList();
            return new PaginationResult<T>(mappedItems, totalRecords, pageNumber, pageSize);
        }
    }
}