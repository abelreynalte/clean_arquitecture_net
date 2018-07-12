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
    public interface IBankAccountRepository: IBaseRepository<BankAccount, string>
    {
        BankAccount findByNumber(String accountNumber);
        BankAccount findByNumberLocked(String accountNumber);
        //void save(BankAccount bankAccount);
        List<BankAccount> listBankAccount(BankAccount bankAccount);
        PageOfBankAccountDto GetBankAccounts(Expression<Func<BankAccount, bool>> filter, string [] includePaths, int page, int pageSize, params SortExpression<BankAccount>[] sortExpressions);

    }
}
