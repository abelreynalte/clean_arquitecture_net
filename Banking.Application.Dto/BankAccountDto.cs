using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto
{
    public class BankAccountDto
    {
        public long id { get; set; }
        public string number { get; set; }
        public decimal balance { get; set; }
        public bool isLocked { get; set; }
        public CustomerDto customer { get; set; }  
    }
}
