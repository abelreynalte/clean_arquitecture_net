using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain.Entity;
using Banking.Application.Notification;

namespace Banking.Domain.NoTransactions
{
    public class BankAccountDomainService
    {
        public void performlistBankAccount(BankAccount bankAccount)
        {
            try
            {
                Notification notification = new Notification();
                this.validateBankAccounts(notification, bankAccount);
                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        private void validateBankAccounts(Notification notification, BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                notification.addError("Cannot list to bankAccounts. Invalid data in bank accounts specifications");
                return;
            }
        }
    }
}
