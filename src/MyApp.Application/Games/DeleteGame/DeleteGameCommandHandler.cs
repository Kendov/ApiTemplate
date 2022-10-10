using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGamesRepository _gameRepository;

        public DeleteGameCommandHandler(IUnitOfWork unitOfWork, IGamesRepository gameRepository)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);
            if (game is null)
            {
                return false;
            }

            _gameRepository.Delete(game);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}