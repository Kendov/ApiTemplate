using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, long>
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGameCommandHandler(IGamesRepository gamesRepository, IUnitOfWork unitOfWork)
        {
            _gamesRepository = gamesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game
            {
                Name = request.Name,
                Description = request.Description,
                Genre = request.Genre,
                Publisher = request.Publisher,
                ReleaseDate = request.ReleaseDate
            };

            _gamesRepository.Insert(game);

            await _unitOfWork.CommitAsync();

            return game.Id;
        }
    }
}