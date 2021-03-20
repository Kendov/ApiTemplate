using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ApiContext Context = new ApiContext();
        public TEntity Add(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
            return obj;
        }

        public void Delete(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
            Context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
            // test.Load();
            // return test.ToList();
        }

        public void Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}