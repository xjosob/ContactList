using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ConsoleApp.MainApp.Services
{
    public class MenuService
    {
        public void Show()
        {
            while (true)
            {
                MainMenu();
            }
        }

        public void MainMenu()
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
                    break;
                case ConsoleKey.D2:
                    break;
                default:
                    break;
            }
        }

        public void ExitOption()
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

        public void CreateOption()
        {
            Console.Clear();
            Console.ReadKey();
        }

        public void ViewOption()
        {
            Console.Clear();
            Console.ReadKey();
        }

        public string InvalidOption(string message)
        {
            Console.Clear();
            return message;
        }
    }
}
