using System;
using MyApp.Domain.Common;

namespace MyApp.Domain.Games
{
    public record Game : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}