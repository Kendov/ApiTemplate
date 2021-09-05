using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyApp.Domain
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Delete(object id);
        void Delete(TEntity obj);
        TEntity GetByID(object id);
        TEntity Insert(TEntity obj);
        void Update(TEntity obj);

    }
}