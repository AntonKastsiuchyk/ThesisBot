using System;
using System.IO;

namespace MiniBot.Support
{
    sealed class Support
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

        public static string GetCurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split(new[] { "\\bin" }, StringSplitOptions.None)[0];
        }
    }
}
