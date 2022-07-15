using System;
using System.Threading.Tasks;
using MyApp.Domain.Common;

namespace MyApp.Domain
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Delete(TEntity obj);
        Task<TEntity> GetByIdAsync(long id);
        TEntity Insert(TEntity obj);
        void Update(TEntity obj);
    }
}