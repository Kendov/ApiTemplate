using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyApp.Domain
{
    public interface IRepositoryBase <TEntity> where TEntity : class
    {
        void Commit();
        void Delete(object id);
        void Delete(TEntity obj);
        void Dispose();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetByID(object id);
        TEntity Insert(TEntity obj);
        void Update(TEntity obj);

    }
}