using Microsoft.EntityFrameworkCore;
using MyApp.Domain;

namespace MyApp.Infrastructure.Data
{
    public class ApiContext : DbContext
    {
        // public ApiContext(DbContextOptions options) : base(options)
        // {
        // }
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options
            .UseLazyLoadingProxies()
            .UseNpgsql("Host=127.0.0.1;Port=5432;Database=postgres;Username=desktop;");
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }


    }
}