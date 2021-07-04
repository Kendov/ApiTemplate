using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyApp.Domain.Characters;
using MyApp.Domain.Items;
using MyApp.Infrastructure.Mapping;

namespace MyApp.Infrastructure.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            modelBuilder.Entity<Character>(new CharacterMapping().Configure);
            modelBuilder.Entity<Item>(new ItemMapping().Configure);
        }
    }
}