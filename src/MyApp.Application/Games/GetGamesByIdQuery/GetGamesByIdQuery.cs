
using MediatR;

namespace MyApp.Application.Games.GetGamesByIdQuery
{
    public record GetGamesByIdQuery : IRequest<GetGamesByIdQueryResult>
    {
        public int Id { get; set; }
    }
}