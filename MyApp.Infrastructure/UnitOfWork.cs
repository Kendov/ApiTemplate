using Microsoft.EntityFrameworkCore;
using MyApp.Domain;

namespace MyApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
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