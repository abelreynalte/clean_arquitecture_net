using System;

namespace Banking.Application.Exceptions
{
    public class CannotDepositException : Exception
    {
        public CannotDepositException() :
            base("Cannot deposit in the account, it is locked")
        {
        }
    }
}
