using Banking.Domain.Entity;
using Banking.Domain.Repository;
using Banking.Infrastructure.Common;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.EntityFramework
{
    public class BankAccountEFRepository : BaseEFRepository<BankAccount, string>, IBankAccountRepository
    {

        public BankAccountEFRepository(BankingContext context): base(context)
        {

        }   

        public BankAccount findByNumber(String accountNumber)
        {
            //Criteria criteria = getSession().createCriteria(BankAccount.class);
            //criteria.add(Restrictions.eq("number", accountNumber));
            //return (BankAccount) criteria.uniqueResult();
            return BankingContext.BankAccounts.FirstOrDefault(x => x.number == accountNumber);
        }

        public BankAccount findByNumberLocked(String accountNumber)
        {
            //Criteria criteria = getSession().createCriteria(BankAccount.class);
            //criteria.add(Restrictions.eq("number", accountNumber));
            //criteria.setLockMode(LockMode.PESSIMISTIC_WRITE);
            //return (BankAccount) criteria.uniqueResult();

            //var t = BankingContext.BankAccounts.ToList();
            
            return BankingContext.BankAccounts.FirstOrDefault(x => x.number == accountNumber);
        }

        //public void save(BankAccount bankAccount)
        //{
        //    //super.save(bankAccount);
        //    BankingContext.BankAccounts.Add(bankAccount);                        
        //}

        public BankingContext BankingContext
        {
            get { return Context as BankingContext; }
        }
    }
}
