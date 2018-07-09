using Banking.Domain.Entity;
using Banking.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Repository
{
    public interface IBankAccountRepository: IBaseRepository<BankAccount, string>
    {
        BankAccount findByNumber(String accountNumber);
        BankAccount findByNumberLocked(String accountNumber);
        //void save(BankAccount bankAccount);
    }
}
