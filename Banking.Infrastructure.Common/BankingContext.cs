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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BankingContext>(null);
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            base.OnModelCreating(modelBuilder);
        }
    }
}
