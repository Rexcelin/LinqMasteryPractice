using System;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Exceptions;
using RestaurantManagementSystem.Utilities;

namespace RestaurantManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();
            CustomerService customerService = new CustomerService();
            OrderService orderService = new OrderService();
            ReportService reportService = new ReportService();

            menuService.MenuItems = JsonFileHandler.LoadData<MenuItem>("menu.json");

            customerService.Customers = JsonFileHandler.LoadData<Customer>("customers.json");

            orderService.Orders = JsonFileHandler.LoadData<Order>("orders.json");

            try
            {
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
                    Console.WriteLine("9. Create Order");
                    Console.WriteLine("10. Display All Orders");
                    Console.WriteLine("11. View Order Details");
                    Console.WriteLine("12. Update Order Status");
                    Console.WriteLine("13. Popular Items Report");
                    Console.WriteLine("14. Sales Report");
                    Console.WriteLine("15. Orders by Status");
                    Console.WriteLine("16. Orders by Date");
                    Console.WriteLine("17. High-Value Orders");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter your choice: ");
                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            menuService.AddItem();
                            JsonFileHandler.SaveData("menu.json", menuService.MenuItems);
                            JsonFileHandler.SaveText("menu.txt", menuService.MenuItems);
                            break;

                        case "2":
                            menuService.DisplayItems();
                            break;

                        case "3":
                            menuService.SearchItem();
                            break;

                        case "4":
                            menuService.UpdateItem();
                            JsonFileHandler.SaveData("menu.json", menuService.MenuItems);
                            JsonFileHandler.SaveText("menu.txt", menuService.MenuItems);
                            break;

                        case "5":
                            menuService.ChangeAvailability();
                            JsonFileHandler.SaveData("menu.json", menuService.MenuItems);
                            JsonFileHandler.SaveText("menu.txt", menuService.MenuItems);
                            break;

                        case "6":
                            customerService.AddCustomer();
                            JsonFileHandler.SaveData("customers.json", customerService.Customers);
                            JsonFileHandler.SaveText("customers.txt", customerService.Customers);
                            break;

                        case "7":
                            customerService.DisplayCustomers();
                            break;

                        case "8":
                            customerService.SearchCustomer();
                            break;

                        case "9":
                            orderService.CreateOrder(menuService, customerService);
                            JsonFileHandler.SaveData("orders.json", orderService.Orders);
                            JsonFileHandler.SaveText("orders.txt", orderService.Orders);
                            break;

                        case "10":
                            orderService.DisplayOrders();
                            break;

                        case "11":
                            orderService.DisplayOrderDetails();
                            break;

                        case "12":
                            orderService.UpdateStatus();
                            JsonFileHandler.SaveData("orders.json", orderService.Orders);
                            JsonFileHandler.SaveText("orders.txt", orderService.Orders);
                            break;

                        case "13":
                            reportService.ShowPopularItems(orderService.Orders);
                            break;

                        case "14":
                            reportService.ShowSales(orderService.Orders);

                            break;

                        case "15":
                            reportService.ShowOrdersByStatus(orderService.Orders);
                            break;

                        case "16":
                            reportService.ShowOrdersByDate(orderService.Orders);
                            break;

                        case "17":
                            reportService.ShowHighValueOrders(orderService.Orders);
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
            catch (InvalidMenuItemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter the correct value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The entered number is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}