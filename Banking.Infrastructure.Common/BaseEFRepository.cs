using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public class BaseEFRepository<TEntity, TKey>: IBaseRepository<TEntity, TKey>, IDisposable
        where TEntity : class
    {
        protected readonly DbContext Context;
        //private bool shareContext = false;
        public BaseEFRepository(DbContext context)
        {
            Context = context;
            //shareContext = true;
        }
   
        public void persist(TEntity entity)
        {

        }    

        public void save()
        {
            Context.SaveChanges();
        }

        public void add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            //if (!shareContext)
            save();
        }

        public void update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            save();
        }

        public void delete(TEntity entity)
        {
            //if (entity == null) throw new ArgumentNullException("entity");
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            save();
        }

        public TEntity getById(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void saveOrUpdate(TEntity entity)
        {
            
        }

        public void Dispose()
        {
            //if (shareContext && (Context != null))
            Context.Dispose();
        }
    }
}
