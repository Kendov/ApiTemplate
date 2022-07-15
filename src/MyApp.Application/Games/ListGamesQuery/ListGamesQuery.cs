
using MediatR;
using System.Collections.Generic;

namespace MyApp.Application.Games.ListGamesQuery
{
    public record ListGamesQuery : IRequest<IEnumerable<ListGamesQueryResult>>
    {
    }
}