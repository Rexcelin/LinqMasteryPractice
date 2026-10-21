using System;
using RestaurantManagementSystem.Services;

namespace RestaurantManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();
            CustomerService customerService = new CustomerService();

            while (true)
            {
                Console.WriteLine("\n===== RESTAURANT MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. Display Menu Items");
                Console.WriteLine("3. Search Menu Items");
                Console.WriteLine("4. Update Menu Item");
                Console.WriteLine("5. Change Item Availablitiy");
                Console.WriteLine("6. Register Customer");
                Console.WriteLine("7. Display Customers");
                Console.WriteLine("8. Search Customers");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                 {
                    case "1":
                        menuService.AddItem();
                        break;

                    case "2":
                        menuService.DisplayItems();
                        break;

                    case "3":
                        menuService.SearchItem();
                        break;

                    case "4":
                        menuService.UpdateItem();
                        break;

                    case "5":
                        menuService.ChangeAvailability();
                        break;

                    case "6":
                        customerService.AddCustomer();
                        break;

                    case "7":
                        customerService.DisplayCustomers();
                        break;

                    case "8":
                        customerService.SearchCustomer();
                        break;



                    case "0":
                         Console.WriteLine("Thank you!");
                         return;

                    default:
                         Console.WriteLine("Invalid choice. Try again.");
                         break;
                   }
            }
        }
    }
}