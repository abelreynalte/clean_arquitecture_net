using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Entity.Dtos
{
    public class PageOfCustomerDto
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCount { get; set; }
    }
}
