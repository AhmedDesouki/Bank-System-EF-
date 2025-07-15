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
                Console.WriteLine("2. Add Transaction");
                Console.WriteLine("3. View Customer Transactions");
                Console.WriteLine("4. Exit");
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
                            //AddTransaction(bankingService);
                            break;
                        case "3":
                           // ViewTransactions(bankingService);
                            break;
                        case "4":
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

        }
    }
    
}
