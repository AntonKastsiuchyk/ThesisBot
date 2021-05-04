using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Support
{
    internal class Support
    {
        public static int GetIntFromConsole()
        {
            bool isInt = false;
            int result = default;
            while (!isInt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    Console.ResetColor();
                    isInt = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nIncorrect value. Please input integer value.");
                    Console.ResetColor();
                }
            }
            return result;
        }

        public static string CheckStringForEmpty()
        {
            bool isEmpty = false;
            string resultString = default;
            while (!isEmpty)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string answer = Console.ReadLine();
                Console.ResetColor();
                if (!string.IsNullOrEmpty(answer))
                {
                    resultString = answer;
                    isEmpty = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, you should input answer. Please try again.");
                    Console.ResetColor();
                }
            }
            return resultString;
        }
    }
}
