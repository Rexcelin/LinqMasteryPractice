using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class MenuService
    {
        public List<MenuItem> MenuItems = new List<MenuItem>();

        public void AddItem()
        {
            Console.Write("Enter item ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (MenuItems.Any(item => item.ItemId == id))
            {
                Console.WriteLine("Item ID already exists.");
                return;
            }

            Console.Write("Enter item name: ");
            string? name = Console.ReadLine( );

            Console.Write("Enter category: ");
            string? category = Console.ReadLine( );

            Console.Write("Enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            if (price < 0 || name == null || category == null)
            {
                Console.WriteLine("Invalid item details.");
                return;
            }

            MenuItem item = new MenuItem(id, name, category, price);

            MenuItems.Add(item);

            Console.WriteLine("Menu item added successfully.");
        }

        public void DisplayItems()
        {
            foreach (MenuItem item in MenuItems)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(
                    $"ItemID:{item.ItemId}\tItemName:{item.Name}\tCategory:{item.Category}\tItem Price: Rs.{item.Price}\tAvailable: {item.IsAvailable}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public MenuItem? GetItem(int id)
        {
            return MenuItems.FirstOrDefault(item => item.ItemId == id);
        }

        public void SearchItem()
        {
            Console.Write("Enter item name or category: ");
            string? search = Console.ReadLine();

            var result = MenuItems.Where(item =>
                item.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                item.Category.Contains(search, StringComparison.OrdinalIgnoreCase));

            foreach (MenuItem item in result)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine($"ItemID:{item.ItemId} \t$ItemName:{item.Name} \t $Item Price:Rs.{item.Price}");
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }

        public void UpdateItem()
        {
            Console.Write("Enter item ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            MenuItem? item = GetItem(id);

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            Console.Write("Enter new name: ");
            item.Name = Console.ReadLine() ?? item.Name;

            Console.Write("Enter new category: ");
            item.Category = Console.ReadLine() ?? item.Category;

            Console.Write("Enter new price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            if (price < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            item.Price = price;

            Console.WriteLine("Item updated successfully.");
        }

        public void ChangeAvailability()
        {
            Console.Write("Enter item ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            MenuItem? item = GetItem(id);

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            item.IsAvailable = !item.IsAvailable;

            Console.WriteLine("Availability changed.");
        }
    }
}