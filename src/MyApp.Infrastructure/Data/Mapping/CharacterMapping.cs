using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Characters;
using MyApp.Domain.Items;

namespace MyApp.Infrastructure.Data.Mapping
{
    public class CharacterMapping : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("characters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Class);
            builder.HasMany<Item>(x => x.Items);


        }
    }
}