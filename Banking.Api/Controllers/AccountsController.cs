using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Banking.Application.Dto;
using Banking.Application.Service;
using Banking.Domain.Repository;
using Banking.Domain.Entity;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using Banking.Infrastructure.Common;
using Banking.Domain.Entity.Dtos;
using Banking.Application.Dto.Pagination;

namespace Banking.Api.Controllers
{
    public class AccountsController : ApiController
    {
        NoTransactionApplicationService noTransactionApplicationService = new NoTransactionApplicationService();
        ResponseHandlerController responseHandler = new ResponseHandlerController();

        /*private IMapper mapper;*/
        private readonly IBankAccountRepository bankAccountRepository;
        public AccountsController(/*IMapper mapper, */IBankAccountRepository bankAccountRepository)
        {
            /*this.mapper = mapper;*/
            this.bankAccountRepository = bankAccountRepository;
        }

        [HttpGet]
        [Route("api/listBankAccount")]
        public IHttpActionResult listBankAccounts(int page, int pageSize)
        {
            try
            {
                return Json(GetBankAccounts(page, pageSize));              
            }
            catch (ArgumentException ex)
            {
                return Json(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        private BankAccountList GetBankAccounts(int page, int pageSize)
        {
            var bankAccounts = this.bankAccountRepository.GetBankAccounts(
                p => !p.isLocked,
                new string[] { "Customer" }, //new string[] { "Customer" },
                page,
                pageSize,
                new SortExpression<BankAccount>(p => p.customer.lastName, ListSortDirection.Ascending),
                new SortExpression<BankAccount>(p => p.number, ListSortDirection.Descending));

            var vm = new BankAccountList
            {
                BankAccounts = bankAccounts.BankAccouns.ToList(),
                Page = page,
                TotalCount = bankAccounts.TotalCount
            };

            return vm;

        }
    }
}
