using System;
namespace Helloworld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int Orderid = 0;
            bool isValidOrderid = false;
            int count = 1;
            while(!isValidOrderid || Orderid<=0)
            {
                if (count > 1)
                {
                    Console.WriteLine("Invalid!!");
                }
                Console.WriteLine("Enter Order ID:");
                isValidOrderid=int.TryParse(Console.ReadLine(), out Orderid);
                count++;
            }
            Console.WriteLine("CustomerName");
            string? CustomerName = Console.ReadLine();
            if (string.IsNullOrEmpty(CustomerName)) {
                Console.WriteLine("Invalid!!");
            }
            
           


            Console.WriteLine("ProductName:");
            string? ProductName = Console.ReadLine();
            int quantity = 0;
            bool isValidQuantity = false;
            count = 1;
            while (!isValidQuantity || quantity <= 0)
            {
                if (count > 1)
                {
                    Console.WriteLine("Invalid!!");
                }
                Console.WriteLine("Enter Quantity:");
                isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
                count++;
            }
            decimal UnitPrice;
            decimal price = quantity * UnitPrice;

            Console.WriteLine();
            Console.WriteLine("**************************ORDER SUMMARY***************************");
            Console.WriteLine($"\nORDER ID:{Orderid}\nCUSTOMER NAME:{CustomerName}\nPRODUCT NAME:{ ProductName}\nQUANTITY:{quantity}\nUNIT PRICE:{UnitPrice:F2}");
            Console.WriteLine("******************************************************************");
        }
    }
}


