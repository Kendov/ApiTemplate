using System;
using MyApp.Domain.Common;

namespace MyApp.Domain.Games
{
    public record Game : AuditableEntity
    {
        public const int NAME_MAX_LENGTH = 500;
        public const int DESCRIPTION_MAX_LENGTH = 5000;
        public const int PUBLISHER_MAX_LENGTH = 100;

        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}