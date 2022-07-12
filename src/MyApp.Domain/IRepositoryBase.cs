using System;
using System.Collections.Generic;
using MyApp.Domain.Common;

namespace MyApp.Domain
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Delete(object id);
        void Delete(TEntity obj);
        IEnumerable<TEntity> Get();
        TEntity GetByID(object id);
        TEntity Insert(TEntity obj);
        void Update(TEntity obj);

    }
}