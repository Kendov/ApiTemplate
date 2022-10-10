
using MediatR;

namespace MyApp.Application.Games.GetGamesById
{
    public record GetGamesByIdQuery : IRequest<GetGamesByIdQueryResult>
    {
        public int Id { get; set; }
    }
}