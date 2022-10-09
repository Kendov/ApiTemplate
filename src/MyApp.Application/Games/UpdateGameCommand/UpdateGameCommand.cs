using System;
using MediatR;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.UpdateGameCommand
{
    public record UpdateGameCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}