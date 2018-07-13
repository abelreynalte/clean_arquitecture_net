using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Pagination
{
    public class CustomerList
    {
        public List<Customer> Customers { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
