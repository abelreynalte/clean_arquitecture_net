using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Application.Dto.Enumeration;
using Banking.Domain.Entity;
using Banking.Domain.Transactions.Service;
using Banking.Domain.NoTransactions;
using Banking.Application.Dto;

namespace Banking.Application.Service
{
    public class NoTransactionApplicationService
    {
        private BankAccountDomainService bankAccountDomainService = new BankAccountDomainService();

        //public List<BankAccount> listBankAccounts(BankAccountDto bankAccountDto, 
        //    Func<int, int, BankAccountDto> delegateListBankAccount)
        //{
        //    List<BankAccount> lstBankAccount = delegateListBankAccount(bankAccountDto);
        //    //this.bankAccountDomainService.performlistBankAccount(bankAccountDto);
        //    return lstBankAccount;
        //}
    }
}
