using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity: class
    {
        void persist(TEntity entity);
        void save();
        void add(TEntity entity);
        void update(TEntity entity);
        void delete(TEntity entity);
        void saveOrUpdate(TEntity entity);
        TEntity getById(TKey key);
        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           string[] includePaths = null,
           int? page = 0,
           int? pageSize = null,
           params SortExpression<TEntity>[] sortExpressions);

    }
}
