using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Entity.Dtos
{
    public class PageOfBankAccountDto
    {
        public IEnumerable<BankAccount> BankAccouns { get; set; }
        public int TotalCount { get; set; }
    }
}
