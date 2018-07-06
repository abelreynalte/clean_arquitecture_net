using System;

namespace Banking.Application.Exceptions
{

    public class AmountLessOrEqualToZeroException : Exception
    {
        public AmountLessOrEqualToZeroException()
            : base("The amount cannot be less than or equal to zero")
        {
        }
    }
}
