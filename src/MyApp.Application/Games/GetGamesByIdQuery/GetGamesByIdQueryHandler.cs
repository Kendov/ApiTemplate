using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.GetGamesByIdQuery
{
    public class GetGamesByIdQueryHandler : IRequestHandler<GetGamesByIdQuery, GetGamesByIdQueryResult>
    {
        private readonly IGamesRepository _gamesRepository;

        public GetGamesByIdQueryHandler(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<GetGamesByIdQueryResult> Handle(GetGamesByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _gamesRepository.GetByIdAsync(request.Id);

            if (game is null)
            {
                return null;
            }

            return new GetGamesByIdQueryResult
            {
                Name = game.Name,
                Description = game.Description,
                Genre = game.Genre,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate
            };
        }
    }
}