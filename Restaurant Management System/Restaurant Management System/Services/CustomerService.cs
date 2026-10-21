using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class CustomerService
    {
        public List<Customer> Customers = new List<Customer>();

        public void AddCustomer()
        {
            Console.Write("Enter customer ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (Customers.Any(c => c.CustomerId == id))
            {
                Console.WriteLine("Customer ID already exists.");
                return;
            }

            Console.Write("Enter customer name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string? phone = Console.ReadLine();

            Console.Write("Enter email: ");
            string? email = Console.ReadLine();

            if (name == null || phone == null || email == null)
            {
                Console.WriteLine("Name,phone no,email are required.");
                return;
            }

            Customer customer = new Customer(id, name, phone, email);

            Customers.Add(customer);

            Console.WriteLine("Customer registered successfully.");
        }

        public void DisplayCustomers()
        {
            foreach (Customer customer in Customers)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(
                    $"CustomerID:{customer.CustomerId}\tCustomerName:{customer.Name}\tPhoneNumber:{customer.PhoneNo}\tEmail:{customer.Email}");
            }
        }

        public Customer? GetCustomer(int id)
        {
            return Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void SearchCustomer()
        {
            Console.Write("Enter customer name or phone: ");
            string? search = Console.ReadLine();

            var result = Customers.Where(c =>
                c.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                c.PhoneNo.Contains(search));

            foreach (Customer customer in result)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"CustomerID:{customer.CustomerId}\tCustomerName:{customer.Name}\tPhoneNumber:{customer.PhoneNo}\tEmail:{customer.Email}");
            }
        }
    }
}