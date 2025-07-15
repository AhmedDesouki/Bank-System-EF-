using Bank_System_Aanlysis_EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Aanlysis_EF
{

    public class CustomerService
    {
        private readonly ApplicationDbContext Appcontext; //NULLLLL
        public CustomerService()
        {
            
        }
        public CustomerService(ApplicationDbContext context)
        {
            Appcontext = context;
        }

        public void CreateCustomer(string name, int age)
        {
            var customer = new Customer
            {
                
                Name = name,
                Age = age,
                Balance = 0
            };
            if(customer!=null ) {
                Appcontext.Customers.Add(customer);
                Appcontext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Failed to save to database");
            }

            
        }
        public void CreateAccount(int customerId)
        {
            var customer = Appcontext.Customers.Find(customerId);
            Appcontext.Users.Add(new Account 
            {
             CustomerId = customerId,
            });
            
        }

        public void Deposit(int accountId, decimal amount)
        {
            //deposit for a customer id==id +balance
            //make transaction

            var customer = Appcontext.Customers.Find(accountId);
            customer.Balance += amount;

            Appcontext.Transactions.Add(new Transaction
            {
                Type = "Deposit",
                Amount = amount,
                Date = DateTime.Now,
                customerId = accountId
            });

            Appcontext.SaveChanges();
        }

        public void Withdraw(int accountId, decimal amount)
        {
          
            var customer = Appcontext.Customers.Find(accountId);
            customer.Balance -= amount;

            Appcontext.Transactions.Add(new Transaction
            {
                Type= "Withdraw",
                Amount = amount,
                Date = DateTime.Now,
                customerId = accountId
            });

            Appcontext.SaveChanges();
        }

        public List<Transaction> View_transaction_history(int customerId)
        {
            //1-need to match ids from trans custid
            //2- put the res in list<trans>
            //then return it
            var CustomerWithTransactionHistory = Appcontext.Customers
                .Include(a => a.Transactions)
                .FirstOrDefault(c => c.Id == customerId);
            if (CustomerWithTransactionHistory != null)
            {
                List<Transaction> allTransactions = CustomerWithTransactionHistory.Transactions;

                //foreach (var transaction in allTransactions)
                //{

                //}
                return allTransactions;
            }

           return new List<Transaction>();
        }
    }
}
