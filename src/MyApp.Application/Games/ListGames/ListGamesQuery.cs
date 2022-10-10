
using MediatR;
using System.Collections.Generic;

namespace MyApp.Application.Games.ListGames
{
    public record ListGamesQuery : IRequest<IEnumerable<ListGamesQueryResult>>
    {
    }
}