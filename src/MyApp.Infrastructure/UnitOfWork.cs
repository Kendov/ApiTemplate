using System.Threading.Tasks;
using MyApp.Domain;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void RollBack()
        {

        }

    }
}