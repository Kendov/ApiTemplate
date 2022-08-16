using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Publisher;

namespace MyApp.Infrastructure.Data.Mapping
{
    public class PublisherMapping : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("publishers");
            builder.HasAuditableProperties();

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired();
        }
    }
}