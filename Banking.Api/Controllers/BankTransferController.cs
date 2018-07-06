using Banking.Application.Dto;
using Banking.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Banking.Infrastructure.Common;

namespace Banking.Api.Controllers
{
    public class BankTransferController : ApiController
    {
        //// GET: api/BankTransfer
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/BankTransfer/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/BankTransfer
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/BankTransfer/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/BankTransfer/5
        //public void Delete(int id)
        //{
        //}
        TransactionApplicationService transactionApplicationService = new TransactionApplicationService();
        ResponseHandlerController responseHandler;

        [HttpPost]
        public IHttpActionResult performTransfer(RequestBankTransferDto requestBankTransferDto)
        {
            try
            {
                transactionApplicationService.performTransfer(requestBankTransferDto);
                return this.responseHandler.getOkCommandResponse("Transfer done!");
            }
            catch (ArgumentException ex)
            {
                return this.responseHandler.getAppCustomErrorResponse(ex.Message);
            }
            catch (Exception ex)
            {
                return this.responseHandler.getAppExceptionResponse();
            }
        }
    }
}
