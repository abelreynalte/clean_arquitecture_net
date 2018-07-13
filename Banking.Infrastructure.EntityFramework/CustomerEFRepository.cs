using Banking.Domain.Entity;
using Banking.Domain.Entity.Dtos;
using Banking.Domain.Repository;
using Banking.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.EntityFramework
{
    public class CustomerEFRepository: BaseEFRepository<Customer, string>, ICustomerRepository
    {
        public CustomerEFRepository(BankingContext context): base(context)
        {

        }

        public PageOfCustomerDto GetCustomers(Expression<Func<Customer, bool>> filter, string[] includePaths, int page, int pageSize, params SortExpression<Customer>[] sortExpressions)
        {
            IEnumerable<Customer> customers = this.Get(
                filter,
                includePaths,
                page,
                pageSize,
                sortExpressions);

            return new PageOfCustomerDto() { Customers = customers, TotalCount = pageSize };
        }

        public BankingContext BankingContext
        {
            get { return Context as BankingContext; }
        }
    }
}
