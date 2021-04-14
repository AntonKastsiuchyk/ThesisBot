using LogCustom;
using MiniBot.Entities;
using MiniBot.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Activity
{
    sealed class AssistantBot
    {
        internal static void Hello()
        {
            Logger.Debug("Greeting. Start debug.");
            switch (true)
            {
                case bool morning when morning = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 12:
                    Console.WriteLine("Good morning! Welcome to IT-Academy Pizza!");
                    break;
                case bool day when day = DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 16:
                    Console.WriteLine("Good day! Welcome to IT-Academy Pizza!");
                    break;
                case bool evening when evening = DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 22:
                    Console.WriteLine("Good evening! Welcome to IT-Academy Pizza!");
                    break;
                case bool night when night = DateTime.Now.Hour >= 22 || DateTime.Now.Hour < 8:
                    Console.WriteLine("Good night! Welcome to IT-Academy Pizza!");
                    break;
                default:
                    Console.WriteLine("Hello! Welcome to IT-Academy Pizza!");
                    break;
            }
        }

        internal static void ShowMenuForUser()
        {
            Console.WriteLine("Please choose position from our menu, what you want to see. \n\tMenu:");
            Console.WriteLine($"\t1 - Pizzas\n\t2 - Drinks\n\t3 - Exit");
        }

        internal static void ShowProducts()
        {
        Startloop:
            Console.ForegroundColor = ConsoleColor.Green;
            string answer = Console.ReadLine();
            Console.ResetColor();
            switch (answer)
            {
                case "1":
                    PizzaRepository pizzaRepository = new PizzaRepository();
                    pizzaRepository.GetProducts();
                    break;
                case "2":
                    DrinkRepository drinkRepository = new DrinkRepository();
                    drinkRepository.GetProducts();
                    break;
                case "3":
                    Console.WriteLine("Thanks for your attention. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please input correct answer. (1, 2, 3)");
                    goto Startloop;
            }
        }
    }
}
