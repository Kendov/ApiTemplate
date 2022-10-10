using MediatR;

namespace MyApp.Application.Games.DeleteGame
{
    public record DeleteGameCommand : IRequest<bool>
    {
        public long Id { get; init; }
    }
}