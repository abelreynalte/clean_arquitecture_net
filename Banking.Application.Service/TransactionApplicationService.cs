using Banking.Application.Dto;
using Banking.Application.Dto.Enumeration;
using Banking.Domain.Entity;
using Banking.Domain.Repository;
using Banking.Domain.Transactions.Service;
using Banking.Domain.Transactions;
//using Banking.Application.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Service
{
    public class TransactionApplicationService
    {
        private TransferDomainService transferDomainService = new TransferDomainService();        

        public void performTransfer(RequestBankTransferDto requestBankTransferDto, 
            Func<string, BankAccount> delagatefindByNumberLocked, Action<BankAccount> delegateUpdate)
        {
            Notification.Notification notification = this.validation(requestBankTransferDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            BankAccount originAccount = delagatefindByNumberLocked(requestBankTransferDto.fromAccountNumber);
            BankAccount destinationAccount = delagatefindByNumberLocked(requestBankTransferDto.toAccountNumber);
            this.transferDomainService.performTransfer(originAccount, destinationAccount, requestBankTransferDto.amount);
            delegateUpdate(originAccount);
            delegateUpdate(destinationAccount);
        }        

        private Notification.Notification validation(RequestBankTransferDto requestBankTransferDto)
        {
            Notification.Notification notification = new Notification.Notification();
            if (requestBankTransferDto == null || requestBankTransferDto.getRequestBodyType() == RequestBodyType.INVALID)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            return notification;
        }
    }
}
