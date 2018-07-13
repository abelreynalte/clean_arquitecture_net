using Banking.Domain.Entity;
using Banking.Domain.Entity.Dtos;
using Banking.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Repository
{
    public interface ICustomerRepository
    {
        PageOfCustomerDto GetCustomers(Expression<Func<Customer, bool>> filter, string[] includePaths, int page, int pageSize, params SortExpression<Customer>[] sortExpressions);
    }
}
