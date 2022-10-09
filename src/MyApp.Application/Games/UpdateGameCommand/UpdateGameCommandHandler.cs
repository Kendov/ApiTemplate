using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.UpdateGameCommand
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGameCommandHandler(IGamesRepository gamesRepository, IUnitOfWork unitOfWork)
        {
            _gamesRepository = gamesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            // TODO: Add validation

            var game = await _gamesRepository.GetByIdAsync(request.Id);

            Game gameEntry = new()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Genre = request.Genre,
                Publisher = request.Publisher,
                ReleaseDate = request.ReleaseDate
            };

            game.Name = request.Name;
            game.Description = request.Description;
            game.Genre = request.Genre;
            game.Publisher = request.Publisher;
            game.ReleaseDate = request.ReleaseDate;

            _gamesRepository.Update(game);

            await _unitOfWork.CommitAsync();

            // TODO: Add a better return result object
            return Unit.Value;
        }
    }
}