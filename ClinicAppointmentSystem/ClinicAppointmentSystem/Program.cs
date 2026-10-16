
using System;

namespace ClinicAppointmentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 7)
            {
                Console.WriteLine("\nCLINIC APPOINTMENT SYSTEM");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. View Doctors");
                Console.WriteLine("3. Search Doctor");
                Console.WriteLine("4. Book Appointment");
                Console.WriteLine("5. Cancel Appointment");
                Console.WriteLine("6. View Appointments");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");

                string input = Console.ReadLine() ?? "";

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    choice = 0;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Patient registration selected.");
                        break;

                    case 2:
                        Console.WriteLine("View doctors selected.");
                        break;

                    case 3:
                        Console.WriteLine("Search doctor selected.");
                        break;

                    case 4:
                        Console.WriteLine("Book appointment selected.");
                        break;

                    case 5:
                        Console.WriteLine("Cancel appointment selected.");
                        break;

                    case 6:
                        Console.WriteLine("View appointments selected.");
                        break;

                    case 7:
                        Console.WriteLine("Thank you. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid menu choice.");
                        break;
                }
            }
        }
    }
}
