using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Services;

namespace Presentation.ConsoleApp.MainApp.Services
{
    public class MenuService
    {
        private static readonly ContactService _contactService = new();

        public static void Show()
        {
            while (true)
            {
                MainMenu();
            }
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"{"1.", -5} Add contact");
            Console.WriteLine($"{"2.", -5} View contacts");
            Console.WriteLine($"{"Q.", -5} Quit application");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.Q:
                    ExitOption();
                    break;
                case ConsoleKey.D1:
                    CreateOption();
                    break;
                case ConsoleKey.D2:
                    ViewOption();
                    break;
                default:
                    break;
            }
        }

        public static void ExitOption()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to exit the application? (y/n): ");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Environment.Exit(0);
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    break;
                }
            }
        }

        public static void CreateOption()
        {
            Console.Clear();
            ContactModel contact = new();

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("Phone number: ");
            contact.PhoneNumber = Console.ReadLine();

            _contactService.Add(contact);
            Console.WriteLine(
                $"{contact.FirstName} {contact.LastName} added to contact list! Press any key to continue"
            );
            Console.ReadKey();
        }

        public static void ViewOption()
        {
            Console.Clear();
            var contacts = _contactService.GetAll();

            if (contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(
                        $"{contact.FirstName} {contact.LastName}, email: {contact.Email}, phone number: {contact.PhoneNumber}"
                    );
                }
            }
            else
            {
                InvalidOption("No contacts available.");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        public static void InvalidOption(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
