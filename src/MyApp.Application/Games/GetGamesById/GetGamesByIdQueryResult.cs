using System;
using MyApp.Domain.Games;

namespace MyApp.Application.Games.GetGamesById
{
    public record GetGamesByIdQueryResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}