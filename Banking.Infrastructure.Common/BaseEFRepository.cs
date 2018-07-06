using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public class BaseEFRepository<TEntity>: IBaseRepository<TEntity>, IDisposable
        where TEntity : class
    {
        protected readonly DbContext Context;
        public BaseEFRepository(DbContext context)
        {
            Context = context;
        }
   
        public void persist(TEntity entity)
        {

        }    

        public void save(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void merge(TEntity entity)
        {

        }

        public void saveOrUpdate(TEntity entity)
        {
            
        }
        /*
        protected SessionFactory sessionFactory;

        @Autowired
        public void setSessionFactory(final SessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        protected Session getSession()
        {
            return sessionFactory.getCurrentSession();
        }

        public void persist(T entity)
        {
            getSession().persist(entity);
        }

        public void save(T entity)
        {
            getSession().save(entity);
        }

        public void update(T entity)
        {
            getSession().update(entity);
        }

        public void merge(T entity)
        {
            getSession().merge(entity);
        }

        public void saveOrUpdate(T entity)
        {
            getSession().saveOrUpdate(entity);
        }
        */

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
