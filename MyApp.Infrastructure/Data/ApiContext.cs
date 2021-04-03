using Microsoft.EntityFrameworkCore;
using MyApp.Domain;

namespace MyApp.Infrastructure.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Items> Items { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
        }
    }
}