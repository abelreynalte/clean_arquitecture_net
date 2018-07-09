using Banking.Application.Dto;
using Banking.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Banking.Infrastructure.Common;
using Banking.Domain.Repository;
using Banking.Domain.Entity;

namespace Banking.Api.Controllers
{
    public class BankTransferController : ApiController
    { 
        TransactionApplicationService transactionApplicationService = new TransactionApplicationService();
        ResponseHandlerController responseHandler = new ResponseHandlerController();

        private readonly IBankAccountRepository bankAccountRepository;
        public BankTransferController(IBankAccountRepository bankAccountRepository)
        {
            this.bankAccountRepository = bankAccountRepository;
        }

        [HttpPost]
        [Route("api/transfers")]
        public IHttpActionResult performTransfer([FromBody]RequestBankTransferDto requestBankTransferDto)
        {
            try
            {
                Func<string, BankAccount> delagatefindByNumberLocked = findByNumberLocked;
                Action<BankAccount> delegateUpdate = update;
                transactionApplicationService.performTransfer(requestBankTransferDto, delagatefindByNumberLocked, delegateUpdate);
                return Json(this.responseHandler.getOkCommandResponse("Transfer done!"));
            }
            catch (ArgumentException ex)
            {
                return Json(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return Json(this.responseHandler.getAppExceptionResponse());
            }
        }

        private BankAccount findByNumberLocked(string AccoutNumber)
        {
            return this.bankAccountRepository.findByNumberLocked(AccoutNumber);
        }

        private void update(BankAccount Account)
        {
            this.bankAccountRepository.update(Account);
        }
    }
}
