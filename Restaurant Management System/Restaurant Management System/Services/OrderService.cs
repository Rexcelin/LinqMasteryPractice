using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class OrderService
    {
        public List<Order> Orders = new List<Order>();

        public void CreateOrder(MenuService menuService, CustomerService customerService)
        {
            Console.Write("Enter order ID: ");
            int orderId = Convert.ToInt32(Console.ReadLine());

            if (Orders.Any(o => o.OrderId == orderId))
            {
                Console.WriteLine("Order ID already exists.");
                return;
            }

            Console.Write("Enter customer ID (0 for walk-in): ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            int? savedCustomerId = null;

            if (customerId != 0)
            {
                if (customerService.GetCustomer(customerId) == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                savedCustomerId = customerId;
            }

            Order order = new Order(orderId, savedCustomerId);

            while (true)
            {
                Console.Write("Enter menu item ID (0 to finish): ");
                int itemId = Convert.ToInt32(Console.ReadLine());

                if (itemId == 0)
                {
                    break;
                }

                MenuItem? menuItem = menuService.GetItem(itemId);

                if (menuItem == null || !menuItem.IsAvailable)
                {
                    Console.WriteLine("Item not found or unavailable.");
                    continue;
                }

                Console.Write("Enter quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity < 1)
                {
                    Console.WriteLine("Quantity must be at least 1.");
                    continue;
                }

                OrderItem orderItem = new OrderItem(
                    menuItem.ItemId,
                    menuItem.Name,
                    menuItem.Price,
                    quantity);

                order.Items.Add(orderItem);

                Console.WriteLine("Item added to order.");
            }

            if (order.Items.Count == 0)
            {
                Console.WriteLine("Order must contain at least one item.");
                return;
            }

            Orders.Add(order);

            Console.WriteLine($"Order created. Total: Rs.{order.GrandTotal}");
        }

        public void DisplayOrders()
        {
            foreach (Order order in Orders)
            {
                Console.WriteLine(
                    $"Order ID: {order.OrderId}, Status: {order.Status}, Total: Rs.{order.GrandTotal}");
            }
        }

        public void DisplayOrderDetails()
        {
            Console.Write("Enter order ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Order? order = Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer ID: {order.CustomerId?.ToString() ?? "Walk-in"}");
            Console.WriteLine($"Created: {order.CreatedAt}");
            Console.WriteLine($"Status: {order.Status}");

            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine(
                    $"{item.ItemName} - Quantity: {item.Quantity} - Unit Price: Rs.{item.UnitPrice} - Line Total: Rs.{item.LineTotal}");
            }

            Console.WriteLine($"Grand Total: Rs.{order.GrandTotal}");
        }

        public void UpdateStatus()
        {
            Console.Write("Enter order ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Order? order = Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Console.WriteLine("1. Preparing");
            Console.WriteLine("2. Ready");
            Console.WriteLine("3. Served");
            Console.WriteLine("4. Cancelled");

            Console.Write("Choose status: ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "1" && order.Status == "Placed")
            {
                order.Status = "Preparing";
            }
            else if (choice == "2" && order.Status == "Preparing")
            {
                order.Status = "Ready";
            }
            else if (choice == "3" && order.Status == "Ready")
            {
                order.Status = "Served";
            }
            else if (choice == "4" &&
                     (order.Status == "Placed" ||
                      order.Status == "Preparing" ||
                      order.Status == "Ready"))
            {
                order.Status = "Cancelled";
            }
            else
            {
                Console.WriteLine("Invalid status transition.");
                return;
            }

            Console.WriteLine("Order status updated.");
        }
    }
}