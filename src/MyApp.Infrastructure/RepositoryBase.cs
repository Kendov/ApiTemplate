using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain;
using MyApp.Domain.Common;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{

    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private DbSet<TEntity> _dbSet;
        private AppDbContext _context;
        private bool disposedValue;

        internal DbSet<TEntity> Dbset { get => _dbSet; }

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            return _dbSet.Add(obj).Entity;
        }

        public virtual void Delete(TEntity obj)
        {
            if (_context.Entry(obj).State == EntityState.Detached)
            {
                _dbSet.Attach(obj);
            }
            _dbSet.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RepositoryBase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}