using Banking.Application.Dto.Pagination;
using Banking.Domain.Entity;
using Banking.Domain.Repository;
using Banking.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banking.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        ResponseHandlerController responseHandler = new ResponseHandlerController();
        private readonly ICustomerRepository customerRepository;
        public CustomerController(/*IMapper mapper, */ICustomerRepository customerRepository)
        {
            /*this.mapper = mapper;*/
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var customerFake = "customer-fake";
            return Ok(customerFake);
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            var customersFake = new string[] { "customer-1", "customer-2", "customer-3" };
            return Ok(customersFake);
        }

        [HttpGet]
        public IHttpActionResult listCustomer(int page, int pageSize)
        {
            try
            {
                return Json(GetCustomers(page, pageSize));
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

        private CustomerList GetCustomers(int page, int pageSize)
        {
            var bankAccounts = this.customerRepository.GetCustomers(
                null,
                new string[] { }, //new string[] { "Customer" },
                page,
                pageSize,
                new SortExpression<Customer>(p => p.lastName, ListSortDirection.Ascending),
                new SortExpression<Customer>(p => p.firstName, ListSortDirection.Descending));

            var vm = new CustomerList
            {
                Customers = bankAccounts.Customers.ToList(),
                Page = page,
                TotalCount = bankAccounts.TotalCount
            };

            return vm;

        }
    }
}
