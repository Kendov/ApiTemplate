using System.Collections.Generic;

namespace MyApp.Domain
{
    public interface IRepositoryBase <TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();

        void Dispose();

    }
}