using Banking.Application.Dto.Enumeration;
using Banking.Domain.Entity;
using Banking.Domain.Repository;
using Banking.Domain.Transactions.Service;
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
        private IBankAccountRepository bankAccountRepository;
        private TransferDomainService transferDomainService = new TransferDomainService();

        public void performTransfer(Dto.RequestBankTransferDto requestBankTransferDto)
        {
            Notification.Notification notification = this.validation(requestBankTransferDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            BankAccount originAccount = this.bankAccountRepository.findByNumberLocked(requestBankTransferDto.getFromAccountNumber());
            BankAccount destinationAccount = this.bankAccountRepository.findByNumberLocked(requestBankTransferDto.getToAccountNumber());
            this.transferDomainService.performTransfer(originAccount, destinationAccount, requestBankTransferDto.getAmount());
            this.bankAccountRepository.save(originAccount);
            this.bankAccountRepository.save(destinationAccount);
        }

        private Notification.Notification validation(Dto.RequestBankTransferDto requestBankTransferDto)
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
