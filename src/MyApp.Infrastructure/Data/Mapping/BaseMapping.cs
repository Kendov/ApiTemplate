
using MyApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Infrastructure.Data.Mapping
{
    public static class BaseMapping
    {
        /// <summary>
        /// Extension method to map a BaseEntity.
        /// </summary>
        /// <param name="builder">The EntityFrameworkCore model builder</param>
        /// <typeparam name="T">The entity</typeparam>
        public static void HasBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(x => x.Id);
        }
        /// <summary>
        /// Extension method to map a auditable entity.
        /// </summary>
        /// <param name="builder">The EntityFrameworkCore model builder</param>
        /// <typeparam name="T">The entity</typeparam>
        public static void HasAuditableProperties<T>(this EntityTypeBuilder<T> builder) where T : AuditableEntity
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}