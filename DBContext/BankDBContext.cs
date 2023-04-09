using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accolite_bank_application.Entities;

namespace accolite_bank_application.DBContext
{
    public class BankDBContext : DbContext
    {
        //public BankDBContext()
        //{

        //}
        public BankDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
