using Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Common
{
    public class BankingContext: DbContext
    {
        public BankingContext(): base("ConexionBD")
        {

        }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CourseConfiguration());
        //}
    }
}
