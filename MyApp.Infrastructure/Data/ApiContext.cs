using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Characters;
using MyApp.Domain.Items;

namespace MyApp.Infrastructure.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
        }
    }
}