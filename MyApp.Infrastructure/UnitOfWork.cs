using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;

        public ApiContext Context { get => _context; }

        public UnitOfWork(IDbContextFactory<ApiContext> context)
        {
            _context = context.CreateDbContext();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {

        }

    }
}