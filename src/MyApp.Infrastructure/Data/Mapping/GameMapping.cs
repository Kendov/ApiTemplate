using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Games;

namespace MyApp.Infrastructure.Data.Mapping
{
    internal class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("games");
            builder.HasAuditableProperties();

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(x => x.Genre)
                .IsRequired();

            builder.Property(x => x.Publisher)
                .IsRequired();

            builder.Property(x => x.ReleaseDate)
                .IsRequired();
        }
    }
}