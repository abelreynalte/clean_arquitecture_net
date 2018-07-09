using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
