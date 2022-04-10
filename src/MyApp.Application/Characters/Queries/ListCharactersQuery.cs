using MediatR;
using MyApp.CrossCutting;

namespace MyApp.Domain.Characters.Queries
{
    public class ListCharactersQuery : FilteredQuery, IRequest<FilteredResult<ListCharactersQueryResult>>
    {
    }
}