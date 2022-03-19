using MediatR;
using MyApp.CrossCutting;

namespace MyApp.Application.StackOverflow.Queries
{
    // TODO: return proper result class instead of object
    public class ListPostsQuery : FilteredQuery, IRequest<FilteredResult<object>>
    {

    }
}