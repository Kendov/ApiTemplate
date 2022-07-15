using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.ListGamesQuery
{
    public class ListGamesQueryHandler : IRequestHandler<ListGamesQuery, IEnumerable<ListGamesQueryResult>>
    {
        private readonly IGamesRepository _gameRepository;

        public ListGamesQueryHandler(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<IEnumerable<ListGamesQueryResult>> Handle(ListGamesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}