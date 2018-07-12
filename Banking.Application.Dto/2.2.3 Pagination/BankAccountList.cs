using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Pagination
{
    public class BankAccountList
    {
        public List<BankAccount> BankAccounts{ get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
