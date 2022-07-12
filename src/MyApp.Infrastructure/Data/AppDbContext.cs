using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Games;
using MyApp.Infrastructure.Data.Mapping;

namespace MyApp.Infrastructure.Data
{
    internal class AppDbContext : DbContext
    {

        public DbSet<Game> Games { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            modelBuilder.Entity<Game>(new GameMapping().Configure);
        }
    }
}