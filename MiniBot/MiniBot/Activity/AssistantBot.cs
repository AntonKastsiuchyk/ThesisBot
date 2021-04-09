using MiniBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Activity
{
    sealed class AssistantBot
    {
        public Basket Basket { get; set; }
        public User User { get; set; }

        internal static void Hello()
        {
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
            Console.WriteLine("Are you want to see our menu? (y or n)");
            startloop:
            string answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
                case "Y":
                    Console.WriteLine($"1 - Pizzas\n2-Drinks");
                    break;
                case "N":
                    Console.WriteLine("Thanks for your attention. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please input correct answer. (y or n)");
                    goto startloop;
            }
        }

    }
}
