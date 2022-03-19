using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.CrossCutting;
using MyApp.CrossCutting.Extensions;
using MyApp.Domain.Dapper;

namespace MyApp.Application.StackOverflow.Queries
{
    public class ListPostsQueryHandler : IRequestHandler<ListPostsQuery, FilteredResult<object>>
    {
        private readonly IDapperContext _context;

        public ListPostsQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public Task<FilteredResult<object>> Handle(ListPostsQuery request, CancellationToken cancellationToken)
        {
            var query = @"
            SELECT
            posts.*
            FROM Posts posts
            ";

            return Task.FromResult(_context.Context.Paginate<object>(query, request.Page, request.PageSize));
        }

    }
}