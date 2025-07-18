using Bank_System_Aanlysis_EF.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bank_System_Aanlysis_EF
{
    public class Program
    {
        static void Main(string[] args)
        {


            
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Banking System Console App");
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View Transactions History");
                Console.WriteLine("5. View Balance");
                
                Console.WriteLine("............................Admin................");
                Console.WriteLine("6. View All Customers");
                Console.WriteLine("7. Search Customer");
                Console.WriteLine("8. wealthy Customers (Using sql queries)");

                Console.WriteLine("10. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                using (var context = new ApplicationDbContext())
                {
                    CustomerService customerservice = new CustomerService(context);
                    AdminService adminservice = new AdminService(context);

                    switch (option)
                    {
                        case "1":
                            CreateCustomer(customerservice);
                            break;
                        case "2":
                            deposit(customerservice);
                            break;
                        case "3":
                            Withdraw(customerservice);
                            break;
                        case "4":
                            ViewTransHistory(customerservice);
                            break;
                        case "5":
                            ViewBalance(customerservice);
                            break;
                        case "6":
                            AllCustomers(adminservice);
                            break;
                        case "7":
                            SearchCustomer(adminservice);
                            break;
                        case "8":
                            wealthycustomers(adminservice);
                            break;
                        case "10":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            static void CreateCustomer(CustomerService service)
            {
                Console.Write("Enter customer name: ");
                var name = Console.ReadLine();

                Console.Write("Enter customer Age: ");
                string ageInput = Console.ReadLine();
                //int age = Convert.ToInt32(Console.ReadLine());
                if (int.TryParse(ageInput, out int age))
                {
                    
                    service.CreateCustomer(name, age);
                }
                else
                {
                    Console.WriteLine("Invalid age input.");
                    
                }

                service.CreateCustomer(name, age);
                Console.WriteLine($"DONE");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            static void deposit(CustomerService service)
            {
                Console.Write("Enter customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("Invalid customer ID");
                    return;
                }

                Console.Write("Enter amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount");
                    return;
                }

                service.Deposit(customerId, amount);
                Console.WriteLine($"DONE");
                Console.ReadKey();
            }

            static void Withdraw(CustomerService service)
            {
                Console.Write("Enter customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("Invalid customer ID");
                    return;
                }

                Console.Write("Enter amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount");
                    return;
                }

                service.Withdraw(customerId, amount);
                Console.WriteLine($"DONE");
                Console.ReadKey();
            }

            static void ViewTransHistory(CustomerService service)
            {
                Console.Write("Enter customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("Invalid customer ID");
                    return;
                }
                var res=service.View_transaction_history(customerId);
                foreach (var transaction in res)
                {
                    Console.WriteLine($"Transaction ID: {transaction.Id} Type: {transaction.Type} Amount: {transaction.Amount} Date: {transaction.Date}");
                }
                Console.WriteLine($"DONE");
                Console.ReadKey();
            }  
            
            static void ViewBalance(CustomerService service)
            {
                Console.Write("Enter customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("Invalid customer ID");
                    return;
                }
                decimal cutomerBalance=service.View_balance(customerId);
                Console.WriteLine($"your balance is : {cutomerBalance}$");
                Console.ReadKey();
            }

            static void AllCustomers(AdminService service)
            {
                service.AllCustomers();
            }
            static void SearchCustomer(AdminService service)
            {
                Console.Write("Enter customer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int customerId))
                {
                    Console.WriteLine("Invalid customer ID");
                    return;
                }
                service.SearchCustomer(customerId);
            }

            static void wealthycustomers(AdminService service)
            {
                var wealthyCustomers= service.wealthyCustomers();

                foreach (var customer in wealthyCustomers)
                {
                    Console.WriteLine($"Name : {customer.Name} Balance : {customer.Balance}");
                }
                Console.ReadKey();

            }

        }
    }
    
}
