
using System;
using System.Collections.Generic;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class ReportService
    {
        public void ShowPopularItems(List<Order> orders)
        {
            Console.WriteLine("Popular Items Report");

            foreach (Order order in orders)
            {
                foreach (var item in order.Items)
                {
                    Console.WriteLine(item.ItemName +
                        " - Quantity: " + item.Quantity);
                }
            }
        }

        public void ShowSales(List<Order> orders)
        {
            decimal total = 0;

            foreach (Order order in orders)
            {
                if (order.Status == "Served")
                {
                    total = total + order.GrandTotal;
                }
            }

            Console.WriteLine("Total sales: Rs." + total);
        }

        public void ShowOrdersByStatus(List<Order> orders)
        {
            Console.Write("Enter status: ");
            string? status = Console.ReadLine();

            foreach (Order order in orders)
            {
                if (order.Status.Equals(
                    status, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Order ID: " + order.OrderId);
                    Console.WriteLine("Total: Rs." + order.GrandTotal);
                }
            }
        }

        public void ShowOrdersByDate(List<Order> orders)
        {
            Console.Write("Enter date (yyyy-MM-dd): ");
            string? input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime date))
            {
                foreach (Order order in orders)
                {
                    if (order.CreatedAt.Date == date.Date)
                    {
                        Console.WriteLine("Order ID: " + order.OrderId);
                        Console.WriteLine("Status: " + order.Status);
                        Console.WriteLine("Total: Rs." + order.GrandTotal);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid date.");
            }
        }

        public void ShowHighValueOrders(List<Order> orders)
        {
            Console.Write("Enter minimum order total: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                foreach (Order order in orders)
                {
                    if (order.GrandTotal > amount)
                    {
                        Console.WriteLine("Order ID: " + order.OrderId);
                        Console.WriteLine("Total: Rs." + order.GrandTotal);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
    }
}
