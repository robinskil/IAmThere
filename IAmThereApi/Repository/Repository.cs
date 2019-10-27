using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using Microsoft.EntityFrameworkCore;

namespace IAmThereApi.Repository
{
    public interface IRepository<T>
    { 
        T GetEntity(Expression<Func<T, bool>> predicate);
        ICollection<T> GetEntities();
        ICollection<T> GetEntities(Expression<Func<T, bool>> predicate);
        void AddEntity (T entity);
        void AddEntities(ICollection<T> entities);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
    }

    public class Repository<T> : IRepository<T> where T:class
    {
        protected DataContext Context { get; }
        public Repository(DataContext dataContext)
        {
            Context = dataContext;
        }
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }
        public virtual ICollection<T> GetEntities()
        {
            return Context.Set<T>().ToArray();
        }
        public virtual ICollection<T> GetEntities(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToArray();
        }
        public T GetEntity(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual void AddEntity(T entity)
        {
            Context.Add<T>(entity);
        }

        public virtual void AddEntities(ICollection<T> entities)
        {
            Context.AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
