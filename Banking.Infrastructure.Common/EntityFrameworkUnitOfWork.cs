using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public class EntityFrameworkUnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        public EntityFrameworkUnitOfWork(DbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
