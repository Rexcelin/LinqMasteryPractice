using System;

namespace RestaurantManagementSystem.Exceptions
{
    public class InvalidMenuItemException : Exception
    {
        public InvalidMenuItemException(string msg) : base(msg)
        {
            Console.WriteLine("Invalid menu item");
        }
    }
}