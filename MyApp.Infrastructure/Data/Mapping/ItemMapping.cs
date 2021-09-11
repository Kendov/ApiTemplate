using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Items;

namespace MyApp.Infrastructure.Data.Mapping
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Qtd);
            builder.HasOne(x => x.Character);
        }
    }
}