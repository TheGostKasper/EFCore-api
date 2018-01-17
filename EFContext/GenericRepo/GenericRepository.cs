using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFContext.GenericRepo
{
    public class GenericRepository<T> :
      IGenericRepository<T> where T : class , new()
    {
        private readonly SchoolContext _entities;

        public GenericRepository(SchoolContext schoolContext)
        {
            _entities = schoolContext;
        }
        //private C _entities = new C();
        //public SchoolContext Context
        //{

        //    get { return _entities; }
        //    set { _entities = value; }
        //}

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            this.Save();
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            this.Save();
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            //this.Save();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
