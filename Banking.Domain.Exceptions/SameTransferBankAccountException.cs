using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
public class SameTransferBankAccountException : Exception {
    public SameTransferBankAccountException():
        base("Cannot transfer money to the same bank account"){
    }
}
}
