using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public interface IBaseRepository<TEntity>
        where TEntity: class
    {
        void persist(TEntity entity);
        void save(TEntity entity);
        void update(TEntity entity);
        void merge(TEntity entity);
        void saveOrUpdate(TEntity entity);
        
    }
}
