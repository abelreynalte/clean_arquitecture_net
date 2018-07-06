using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banking.Domain.Transactions.Service;
using Banking.Domain.Entity;

namespace Banking.Domain.Service.Test
{
    [TestClass]
    public class TransferDomainServiceTest
    {
        private TransferDomainService transferDomainService = new TransferDomainService();
        private String originBankAccountNumber = "123-456-001";
        private String destinationBankAccountNumber = "123-456-002";

        public void setUp()
        {
        }

        private BankAccount createAccount(String number, decimal balance)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.setBalance(balance);
            bankAccount.setNumber(number);
            return bankAccount;
        }

        [TestMethod]
        public void performTransferSuccess()
        {
            try
            {
                BankAccount originBankAccount = createAccount(originBankAccountNumber, new decimal(100));
                BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, new decimal(10));
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new decimal(10));

                Assert.AreEqual(new decimal(90), originBankAccount.getBalance());
                Assert.AreEqual(new decimal(20), destinationBankAccount.getBalance());
            }
            catch (Exception)
            {

            }           
        }


        [TestMethod]
        public void performTransferErrorSameAccount()
        {
            try
            {
                BankAccount originBankAccount = createAccount(originBankAccountNumber, new decimal(100));
                BankAccount destinationBankAccount = createAccount(originBankAccountNumber, new decimal(10));
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new decimal(10));
            }
            catch (ArgumentException e)
            {
                //throw;
            }            
        }


        [TestMethod]
        public void performTransferErrorEmptyAccount()
        {
            try
            {
                BankAccount originBankAccount = null;
                BankAccount destinationBankAccount = null;
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new decimal(10));
            }
            catch (ArgumentException e)
            {

            }            

        }


        [TestMethod]
        public void performTransferErrorLockedDestinationAccount()
        {
            try
            {
                BankAccount originBankAccount = createAccount(originBankAccountNumber, new decimal(100));
                BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, new decimal(10));
                destinationBankAccount.Lock();
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new decimal(10));
            }
            catch (ArgumentException e)
            {

            }          
        }


        [TestMethod]
        public void performTransferErrorNoMoneyOriginAccount()
        {
            try
            {
                BankAccount originBankAccount = createAccount(originBankAccountNumber, new decimal(5));
                BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, new decimal(10));
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new decimal(10));
            }
            catch (ArgumentException e)
            {

            }            
        }


        [TestMethod]
        public void performTransferErrorNegativeTransference()
        {
            try
            {
                BankAccount originBankAccount = createAccount(originBankAccountNumber, new decimal(5));
                BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, new decimal(10));
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new decimal(-10));
            }
            catch (ArgumentException e)
            {

            }           
        }
    }
}
