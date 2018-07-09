using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banking.Domain.Entity
{
    public class Customer
    {
        //private long id;
        //private string firstName;
        //private string lastName;
        //private List<BankAccount> bankAccounts;
        [Key]
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<BankAccount> bankAccounts { get; set; }

        public string getFullName()
        {
            return string.Format("{0}, {1}", lastName, firstName);
        }

        //public long getId()
        //{
        //    return id;
        //}

        //public void setId(long id)
        //{
        //    this.id = id;
        //}

        //public string getFirstName()
        //{
        //    return firstName;
        //}

        //public void setFirstName(string firstName)
        //{
        //    this.firstName = firstName;
        //}

        //public string getLastName()
        //{
        //    return lastName;
        //}

        //public void setLastName(string lastName)
        //{
        //    this.lastName = lastName;
        //}

        //public List<BankAccount> getBankAccounts()
        //{
        //    return bankAccounts;
        //}

        //public void setBankAccounts(List<BankAccount> bankAccounts)
        //{
        //    this.bankAccounts = bankAccounts;
        //}
    }
}
