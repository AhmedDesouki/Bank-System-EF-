using Bank_System_Aanlysis_EF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Aanlysis_EF
{
    public class AdminService:PersonService
    {
        private readonly ApplicationDbContext Appcontext;
        public AdminService(ApplicationDbContext context)
        {
            Appcontext = context;
        }

        public void AllCustomers()
        {
            var allCustomers = Appcontext.Customers.ToList();

            foreach (var customer in allCustomers)
            {
                Console.WriteLine($"Customer: {customer.Name}, Balance: {customer.Balance:C}");
                
            }
            Console.ReadKey();
        }

        public void SearchCustomer(int id)
        {
            var customer = Appcontext.Customers.Find(id);
            if (customer != null)
            {
                Console.WriteLine($"Found customer: {customer.Name}");
                
            }
            else
            {
                Console.WriteLine("No Customer found");
            }
            Console.ReadKey();

        }

        public List<Customer> wealthyCustomers() {

            var wealthyCustomers = Appcontext.Customers
                .FromSqlRaw("SELECT * FROM Customers WHERE Balance>5000")
                .ToList();

            return wealthyCustomers;
        }
    }
}
