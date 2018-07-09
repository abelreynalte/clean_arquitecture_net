using Banking.Domain.Entity;
using Banking.Application.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Transactions.Service
{
    public class TransferDomainService
    {

        public void performTransfer(BankAccount originAccount, BankAccount destinationAccount, decimal amount)
        {
            try
            {
                Notification notification = this.validation(originAccount, destinationAccount, amount);
                if (notification.hasErrors())
                {
                    throw new ArgumentException(notification.errorMessage());
                }
                originAccount.withdrawMoney(amount);
                destinationAccount.depositMoney(amount);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentNullException(e.Message);
            }
            
        }

        private Notification validation(BankAccount originAccount, BankAccount destinationAccount, decimal amount)
        {
            Notification notification = new Notification();
            this.validateAmount(notification, amount);
            this.validateBankAccounts(notification, originAccount, destinationAccount);
            return notification;
        }

        private void validateAmount(Notification notification, decimal amount)
        {
            if (amount == null)
            {
                notification.addError("amount is missing");
                return;
            }
            if (amount <= 0)
            {
                notification.addError("The amount must be greater than zero");
            }
        }

        private void validateBankAccounts(Notification notification, BankAccount originAccount, BankAccount destinationAccount)
        {
            if (originAccount == null || destinationAccount == null)
            {
                notification.addError("Cannot perform the transfer. Invalid data in bank accounts specifications");
                return;
            }
            if (originAccount.number.Equals(destinationAccount.number))
            {
                notification.addError("Cannot transfer money to the same bank account");
            }
        }
    }
}
