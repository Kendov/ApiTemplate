using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using Dapper;
using DapperQueryBuilder;

namespace MyApp.CrossCutting.Extensions
{
    public static class PaginateExtension
    {
        // TODO: remove limite size from query and add directli on filteredResult
        // TODO: validate invalid numbers i.e -3
        public static FilteredResult<T> Paginate<T>(this IEnumerable<T> item, int page, int pageSize)
        {
            var result = item
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new FilteredResult<T>
            {
                Total = result.Count(), // TODO: it should be the total of all items
                Result = result
            };
        }

        public static FilteredResult<T> Paginate<T>(this IDbConnection dbConnection, string query, int page, int pageSize, string orderBy = null, object param = null)
        {
            string order = orderBy ?? "1";
            var offset = (page - 1) * pageSize;

            // var totalQuery = dbConnection.QueryBuilder(@$"
            //     WITH Data_CTE AS ({query}) select COUNT(*) from Data_CTE
            // ");

            // var total = totalQuery.QuerySingleOrDefault<int>();
            var totalQuery = @$"WITH Data_CTE AS ({query}) select COUNT(*) from Data_CTE";
            var total = dbConnection.QueryFirst<long>(totalQuery);

            // var querybuilder = dbConnection.QueryBuilder(@$"
            //     {query}
            //     ORDER BY ({order})
            //     OFFSET {offset} ROWS
            //     FETCH NEXT {pageSize} ROWS ONLY;
            // ").Query<T>();

            var formatedQuery = @$"
                WITH Data_CTE AS (
                    @Query
                ) select * from Data_CTE
                ORDER BY (@Order)
                OFFSET @Offser ROWS
                FETCH NEXT @PageSize ROWS ONLY
            ";

            var paginationData = new
            {
                Order = order,
                Offset = offset,
                PageSize = pageSize,
                Query = query
            };

            var result = dbConnection.Query<T>(formatedQuery, MergeObjects(param, paginationData));

            return new FilteredResult<T>
            {
                Total = total,
                Result = result
            };
        }

        private static object MergeObjects(object objectA, object objectB)
        {
            var dictionayA = (Dictionary<string, object>)objectA;
            var dictionayB = (Dictionary<string, object>)objectB;
            var dynamic = new ExpandoObject();

            return dictionayA.Concat(dictionayB);
        }
    }
}
