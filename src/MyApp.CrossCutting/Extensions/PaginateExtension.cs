using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyApp.CrossCutting.Extensions
{
    public static class PaginateExtension
    {
        public static FilteredResult<T> Paginate<T>(this IEnumerable<T> item, int page, int pageSize)
        {
            var result = item
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new FilteredResult<T>
            {
                Total = item.Count(),
                Result = result
            };
        }
    }
}
