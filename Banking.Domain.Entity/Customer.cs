using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banking.Domain.Entity
{
    public class Customer
    {
        [Key]
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public BankAccount bankAccount { get; set; }

        public string getFullName()
        {
            return string.Format("{0}, {1}", lastName, firstName);
        }
    }
}
