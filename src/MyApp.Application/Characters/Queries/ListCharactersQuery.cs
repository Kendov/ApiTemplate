using MediatR;
using MyApp.Application.Characters.Results;
using MyApp.CrossCutting;

namespace MyApp.Domain.Characters.Queries
{
    public class ListCharactersQuery : FilteredQuery, IRequest<FilteredResult<CharacterQueryResult>>
    {
    }
}