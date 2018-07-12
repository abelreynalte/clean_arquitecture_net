using Banking.Application.Exceptions;
using Banking.Application.Notification;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Entity
{
    public class BankAccount
    {
        [Key]
        public long id { get; set; }
        public string number { get; set; }
        public decimal balance { get; set; }
        public bool isLocked { get; set; }
        public Customer customer { get; set; }

        public void Lock()
        {
            if (!isLocked)
            {
                isLocked = true;
            }
        }

        public void unLock()
        {
            if (isLocked)
            {
                isLocked = false;
            }
        }

        public bool hasIdentity()
        {
            return !string.IsNullOrEmpty(number);
        }

        public void withdrawMoney(decimal amount)
        {
            Notification notification = this.withdrawValidation(amount);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            this.balance = this.balance - amount;
        }

        public void depositMoney(decimal amount)
        {
            Notification notification = this.depositValidation(amount);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            this.balance = this.balance + amount;
        }

        public Notification withdrawValidation(decimal amount)
        {
            Notification notification = new Notification();
            this.validateAmount(notification, amount);
            this.validateBankAccount(notification);
            this.validateBalance(notification, amount);
            return notification;
        }

        public Notification depositValidation(decimal amount)
        {
            Notification notification = new Notification();
            this.validateAmount(notification, amount);
            this.validateBankAccount(notification);
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

        private void validateBankAccount(Notification notification)
        {
            if (!this.hasIdentity())
            {
                notification.addError("The account has no identity");
            }
            if (this.isLocked)
            {
                notification.addError("The account is locked");
            }
        }

        private void validateBalance(Notification notification, decimal amount)
        {
            if (this.balance == null)
            {
                notification.addError("balance cannot be null");
            }
            if (!this.canBeWithdrawed(amount))
            {
                notification.addError("Cannot withdraw in the account, amount is greater than balance");
            }
        }

        public bool canBeWithdrawed(decimal amount)
        {
            return !this.isLocked && (this.balance.CompareTo(amount) >= 0);
        }
    }
}
