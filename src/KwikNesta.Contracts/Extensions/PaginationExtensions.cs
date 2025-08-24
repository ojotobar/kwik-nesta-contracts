using KwikNesta.Contracts.Models;

namespace KwikNesta.Contracts.Extensions
{
    public static class PaginationExtensions
    {
        public static Paginator<T> Paginate<T>(this IEnumerable<T> source,
                                               int pageNumber,
                                               int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new Paginator<T>(items, count, pageNumber, pageSize);
        }
    }
}
