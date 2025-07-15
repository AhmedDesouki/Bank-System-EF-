using Bank_System_Aanlysis_EF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Aanlysis_EF
{
    public class ApplicationDbContext : DbContext
    {
        
        //my entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("Data Source=.;Initial Catalog=BankSysSURE;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

           // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Balance)
                .HasPrecision(18, 2);  // specify the digits because A customer's $100.50 balance could become $100 
            modelBuilder.Entity<Transaction>()
                .Property(a=>a.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Customer>()
                .HasData(new Customer[] 
                {
                new Customer { Id = 1,Name="ahmed",Age=22,Balance=3000},
                new Customer { Id = 2,Name="mohamed",Age=24,Balance=4000},
                new Customer { Id = 3,Name="hazem",Age=44,Balance=6000},
                new Customer { Id = 4,Name="mohamed",Age=24,Balance=8000},
                new Customer { Id = 5,Name="mohamed",Age=24,Balance=9000},

                });
            modelBuilder.Entity<Admin>()
                .HasData(new Admin[]
                {
                    new Admin { Id = 1,Name="Omar",Age=44},
                    new Admin { Id = 2,Name="mazen",Age=55},
                });

            modelBuilder.Entity<Account>()
                .HasData(new Account[] 
                {
                new Account { Id = 1,CustomerId=2},
                new Account { Id = 2,CustomerId=3},
                });
            modelBuilder.Entity<Transaction>()
                .HasData(new Transaction[] 
                { 
                new Transaction { Id = 1,Type="deposit",Date=new DateTime(2025, 7, 15),customerId=2},
                new Transaction { Id = 2,Type="withdraw",Date=new DateTime(2025, 6, 22),customerId=3}
                });
        }


    }
}
