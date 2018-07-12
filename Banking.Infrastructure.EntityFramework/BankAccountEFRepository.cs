using Banking.Domain.Entity;
using Banking.Domain.Repository;
using Banking.Infrastructure.Common;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain.Entity.Dtos;
using System.Linq.Expressions;

namespace Banking.Infrastructure.EntityFramework
{
    public class BankAccountEFRepository : BaseEFRepository<BankAccount, string>, IBankAccountRepository
    {

        public BankAccountEFRepository(BankingContext context): base(context)
        {

        }   

        public BankAccount findByNumber(String accountNumber)
        {                        
            return BankingContext.BankAccounts.FirstOrDefault(x => x.number == accountNumber);
        }

        public BankAccount findByNumberLocked(String accountNumber)
        {            
            return BankingContext.BankAccounts.FirstOrDefault(x => x.number == accountNumber);
        }
        
        public List<BankAccount> listBankAccount(BankAccount bankAccount)
        {
            return BankingContext.BankAccounts.ToList();
        }

        public PageOfBankAccountDto GetBankAccounts(Expression<Func<BankAccount, bool>> filter, string [] includePaths, int page, int pageSize, params SortExpression<BankAccount>[] sortExpressions)
        {
            IEnumerable<BankAccount> bankAccounts = this.Get(
                filter,
                includePaths,
                page,
                pageSize,
                sortExpressions);

            return new PageOfBankAccountDto() { BankAccouns = bankAccounts, TotalCount = pageSize };
        }

        public BankingContext BankingContext
        {
            get { return Context as BankingContext; }
        }
    }
}
