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
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                using (var context = new ApplicationDbContext())
                {
                    CustomerService customerservice = new CustomerService(context);

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

        }
    }
    
}
