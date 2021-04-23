using LogCustom;
using MiniBot.Events;
using MiniBot.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    [DebuggerDisplay("Name = {Name}; Email = {Email}; Adress = {Adress}")]
    class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public static event EventHandler<UserEmailContainAdressEventArgs> UserEmailContainAdress;

        internal string GetName(User user)
        {
            Console.WriteLine("\nPlease input your name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();

            return user.Name = name;
        }

        internal string GetAdress(User user)
        {
            Console.WriteLine("\nPlease input your adress.");

            Console.WriteLine("City: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string city = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Street: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string street = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("House number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string numberOfHouse = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Flat number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var numberOfFlat = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            user.Adress = $"{city}, {street}, {numberOfHouse} - {numberOfFlat}";

            return user.Adress;
        }

        internal string GetEmail(User user)
        {
            Console.WriteLine("\nPlease input your email (example@example.com): ");
        Startloop:
            Console.ForegroundColor = ConsoleColor.Green;
            string email = Console.ReadLine();
            Console.ResetColor();

            try
            {
                CheckEmail(email);
            }
            catch (EmailMessageException ex)
            {
                Logger.Error($"{ex.Message}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour email is invalid. Please try again. (example@example.com)");
                Console.ResetColor();
                goto Startloop;
            }
            catch (Exception ex)
            {
                Logger.Error($"{ex.Message}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour email is invalid. Please try again. (example@example.com)");
                Console.ResetColor();
                goto Startloop;
            }

            user.Email = email;
            OnUserEmailContainAdress(new UserEmailContainAdressEventArgs(Email, Name));
            return user.Email;
        }

        internal static void CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmailMessageException($"Email is empty.");
            }

            string[] splitEmail = email.Split('@');

            bool isEmptyFirstString = string.IsNullOrWhiteSpace(splitEmail[0]);
            bool isEmptySecondString = string.IsNullOrWhiteSpace(splitEmail[1]);

            int countDotInFirstSplitString = splitEmail[0].Split('.').Length;
            bool countDotInFirstString = countDotInFirstSplitString >= 1;

            int countDotInSecondSplitString = splitEmail[1].Split('.').Length;
            bool countDotInSecondString = countDotInSecondSplitString == 2;

            int stringSplitCountAtSign = email.Split('@').Length;
            bool countAtSign = stringSplitCountAtSign == 2;

            int stringSplitCountWhiteSpace = email.Split(' ').Length;
            bool countWhiteSpace = stringSplitCountWhiteSpace == 1;

            if (!countAtSign || isEmptyFirstString || isEmptySecondString || !countWhiteSpace || !countDotInFirstString || !countDotInSecondString)
            {
                throw new EmailMessageException($"Email is invalid: {email}.");
            }
        }

        protected virtual void OnUserEmailContainAdress(UserEmailContainAdressEventArgs eventArgs)
        {
            UserEmailContainAdress?.Invoke(this, eventArgs);
        }
    }
}
