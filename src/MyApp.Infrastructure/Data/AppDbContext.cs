using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Characters;
using MyApp.Domain.Items;
using MyApp.Infrastructure.Data.Mapping;

namespace MyApp.Infrastructure.Data
{
    internal class AppDbContext : DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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