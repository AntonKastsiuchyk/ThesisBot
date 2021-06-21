using LogCustom;
using MiniBot.Events;
using MiniBot.Exceptions;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MiniBot.Entities
{
    [DebuggerDisplay("Name = {Name}; Email = {Email}; Address = {Address}")]
    class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public event EventHandler<UserEmailContainAddressEventArgs> UserEmailContainAddress;

        string GetName()
        {
            Console.WriteLine("\nPlease input your name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Support.Support.CheckStringForEmpty();
            Console.ResetColor();
            return Name = name;
        }

        string GetAddress()
        {
            Console.WriteLine("\nPlease input your address.");

            Console.WriteLine("City: ");
            string city = Support.Support.CheckStringForEmpty();

            Console.WriteLine("Street: ");
            string street = Support.Support.CheckStringForEmpty();

            Console.WriteLine("House number: ");
            string numberOfHouse = Support.Support.CheckStringForEmpty();

            Console.WriteLine("Flat number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int numberOfFlat = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            Address = $"{city}, {street}, {numberOfHouse} - {numberOfFlat}";
            return Address;
        }

        string GetEmail()
        {
            Console.WriteLine("\nPlease input your email (example@example.com): ");
        startloop:
            Console.ForegroundColor = ConsoleColor.Green;
            string email = Console.ReadLine();
            Console.ResetColor();

            try
            {
                CheckEmail(email);
            }
            catch (EmailMessageException ex)
            {
                Logger.Error($"{ex.Message} - {email}.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour email is invalid. Please try again. (example@example.com)");
                Console.ResetColor();
                goto startloop;
            }
            catch (Exception ex)
            {
                Logger.Error($"{ex.Message} - {email}.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour email is invalid. Please try again. (example@example.com)");
                Console.ResetColor();
                goto startloop;
            }

            Email = email; 
            return Email;
        }

        internal void GetInfoOfUser()
        {
            Logger.Debug("Get all info of user.");
            GetName();
            GetAddress();
            GetEmail();
            OnUserEmailContainAddress(new UserEmailContainAddressEventArgs(Email, Name));
        }

        static void CheckEmail(string email)
        {
            Logger.Debug("Check Email of user.");
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmailMessageException("Email is empty.");
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

            if (Regex.Matches(email, @"\p{IsCyrillic}").Count > 0 || !countAtSign || isEmptyFirstString || isEmptySecondString 
                || !countWhiteSpace || !countDotInFirstString || !countDotInSecondString)
            {
                throw new EmailMessageException($"Email is invalid: {email}.");
            }
        }

        protected virtual void OnUserEmailContainAddress(UserEmailContainAddressEventArgs eventArgs)
        {
            UserEmailContainAddress?.Invoke(this, eventArgs);
        }
    }
}
