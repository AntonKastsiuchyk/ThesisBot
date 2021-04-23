﻿using LogCustom;
using MiniBot.Entities;
using MiniBot.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBot.Extensions;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace MiniBot.Activity
{
    sealed class AssistantBot
    {
        internal enum Rating
        {
            Terrible = 0,
            VeryBad = 1,
            Bad = 2,
            SoSo = 3,
            Good = 4,
            Amazing = 5
        }

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

        internal static int ShowProductsFromMenu()
        {
        Startloop:
            Console.ForegroundColor = ConsoleColor.Green;
            int answer = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            switch (answer)
            {
                case 1:
                    PizzaRepository pizzaRepository = new PizzaRepository();
                    pizzaRepository.GetProducts();
                    break;
                case 2:
                    DrinkRepository drinkRepository = new DrinkRepository();
                    drinkRepository.GetProducts();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nThanks for your attention! Goodbye! :)");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct answer. (1 or 2)");
                    Console.ResetColor();
                    goto Startloop;
            }
            return answer;
        }

        internal static int ShowMenuForUser()
        {
            Console.WriteLine("\nPlease choose position from our menu, what you want to see. \n\tMenu:");
            Console.WriteLine($"\t1 - Pizzas\n\t2 - Drinks\n\t3 - Exit");
            return ShowProductsFromMenu();
        }

        internal static void ChoosePizza()
        {
        Startloop:
            Console.WriteLine("\nPlease input № of product to add this product to basket." +
                "\nTo exit please input - 0.");
            Console.ForegroundColor = ConsoleColor.Green;
            int answerId = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            if (answerId >= 1 && answerId <= 30)
            {
                Basket basket = new Basket();
                basket.AddById(answerId);

            LoopForChoise:
                Console.WriteLine("\nAre you want add something to your basket from this list of menu? " +
                    "\nFor \"yes\" please input - 1\nFor \"no\" please input - 0");
                Console.ForegroundColor = ConsoleColor.Green;
                int answerChoice = Support.Support.GetIntFromConsole();
                Console.ResetColor();

                if (answerChoice == 1)
                {
                    goto Startloop;
                }
                else if (answerChoice == 0)
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct answer. (1 or 0)");
                    Console.ResetColor();
                    goto LoopForChoise;
                }
            }
            else if (answerId == 0)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlease input correct № of product. Please try again.");
                Console.ResetColor();
                goto Startloop;
            }
        }

        internal static void ChooseDrink()
        {
        Startloop:
            Console.WriteLine("\nPlease input № of product to add this product to basket." +
                "\nTo exit please input - 0.");
            Console.ForegroundColor = ConsoleColor.Green;
            int answerId = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            if (answerId >= 31 && answerId <= 39)
            {
                Basket basket = new Basket();
                basket.AddById(answerId);

            LoopForChoise:
                Console.WriteLine("\nAre you want add something to your basket from this list of menu? " +
                    "\nFor \"yes\" please input - 1\nFor \"no\" please input - 0");
                Console.ForegroundColor = ConsoleColor.Green;
                int answerChoice = Support.Support.GetIntFromConsole();
                Console.ResetColor();

                if (answerChoice == 1)
                {
                    goto Startloop;
                }
                else if (answerChoice == 0)
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct answer. (1 or 0)");
                    Console.ResetColor();
                    goto LoopForChoise;
                }
            }
            else if (answerId == 0)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlease input correct № of product. Please try again.");
                Console.ResetColor();
                goto Startloop;
            }
        }

        internal static bool ShowBasketOrMenu()
        {
            bool isMenu = false;
        Startloop:
            Console.WriteLine("\nAre you want to go to your basket or want to see our menu? (1 or 2)");
            int answer = Support.Support.GetIntFromConsole();

            if (answer == 1)
            {
                Basket basket = new Basket();
                basket.GetProducts();
            }
            else if (answer == 2)
            {
                isMenu = true;
            }
            else
            {
                Console.WriteLine("\nPlease input correct answer. (1 or 2)");
                goto Startloop;
            }
            return isMenu;
        }

        internal static void ActionWithBasket()
        {
            User.UserEmailContainAdress += User_UserEmailContainAdress;
        Startloop:
            Console.WriteLine("\nPlease choose your next step.\n\t1 - Delete position\n\t2 - Change amount for position" +
                "\n\t3 - Return to menu\n\t4 - Submit order\n\t5 - Exit");
            Console.ForegroundColor = ConsoleColor.Green;
            int answer = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            switch (answer)
            {
                case 1:
                    if (!Basket.CheckForEmpty())
                    {
                    StartloopForCase1:
                        Console.WriteLine("\nPlease input № of product: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int idOfProductForDelete = Support.Support.GetIntFromConsole();
                        Console.ResetColor();

                        if (idOfProductForDelete >= 1 && idOfProductForDelete <= 39)
                        {
                            Basket basket = new Basket();
                            basket.DeleteById(idOfProductForDelete);
                        }
                        else
                        {
                            Console.WriteLine("\nPlease input correct № of product. Please try again.");
                            goto StartloopForCase1;
                        }
                        Basket newBasket = new Basket();
                        newBasket.GetProducts();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBasket is empty. Please choose another step.");
                        Console.ResetColor();
                    }
                    goto Startloop;
                case 2:
                StartloopForCase2:
                    if (!Basket.CheckForEmpty())
                    {
                        Console.WriteLine("\nPlease input № of product: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int idOfProductForUpdate = Support.Support.GetIntFromConsole();
                        Console.ResetColor();
                        if (idOfProductForUpdate >= 1 && idOfProductForUpdate <= 39)
                        {
                            Console.WriteLine("\nPlease input amount:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            int amountOfUser = Support.Support.GetIntFromConsole();
                            Console.ResetColor();
                            Basket basket = new Basket();
                            basket.UpdateById(idOfProductForUpdate, amountOfUser);
                        }
                        else
                        {
                            Console.WriteLine("\nPlease input correct № of product. Please try again.");
                            goto StartloopForCase2;
                        }
                        Basket updateBasket = new Basket();
                        updateBasket.GetProducts();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBasket is empty. Please choose another step.");
                        Console.ResetColor();
                    }
                    goto Startloop;
                case 3:
                StartloopForCase3:
                    int answerForThisCase = ShowMenuForUser();
                    if (answerForThisCase == 1)
                    {
                        ChoosePizza();
                    }
                    if (answerForThisCase == 2)
                    {
                        ChooseDrink();
                    }
                    if (ShowBasketOrMenu() == true)
                    {
                        goto StartloopForCase3;
                    }
                    goto Startloop;
                case 4:
                    if (!Basket.CheckForEmpty())
                    {
                        User user = new User();
                        user.GetName(user);
                        user.GetAdress(user);
                        user.GetEmail(user);

                        Basket order = new Basket();
                        if (order.TotalPrice > 20)
                        {
                            float discountOrder = order.AddDiscount(order);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\nThank you for your order! \nOrder: ");
                            order.ShowShortInfo();
                            Console.WriteLine("\nTotal price of your order: {0:0.00}$", discountOrder);
                            Console.WriteLine($"Adress: {user.Adress}");
                            Console.WriteLine($"\n{user.Name}, please check your email {user.Email} and check status of your order.");
                            Console.ResetColor();
                            GetRating();
                            Thread.Sleep(5_000);
                            SendEmailOrderIsOnTheWay(user.Email, user.Name);
                            Thread.Sleep(5_000);
                            SendEmailOrderDeliveredAndPaid(user.Email, user.Name);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\nThank you for your order! \nOrder №{Basket.Id}: ");
                            order.ShowShortInfo();
                            Console.WriteLine("Total price of your order: {0:0.00}$", order.TotalPrice);
                            Console.WriteLine($"Adress: {user.Adress}");
                            Console.WriteLine($"\n{user.Name}, please check your email {user.Email} and check status of your order.");
                            Console.ResetColor();
                            GetRating();
                            Thread.Sleep(5_000);
                            SendEmailOrderIsOnTheWay(user.Email, user.Name);
                            Thread.Sleep(5_000);
                            SendEmailOrderDeliveredAndPaid(user.Email, user.Name);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBasket is empty. Please choose another step.");
                        Console.ResetColor();
                        goto Startloop;
                    }
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nHave a nice day! Goodbye!:)");
                    Console.ResetColor();
                    break;
            }
        }

        private static void User_UserEmailContainAdress(object sender, Events.UserEmailContainAdressEventArgs user)
        {
            AssistantBot assistantBot = new AssistantBot();
            SendEmailOrderReceive(user.Email, user.Name).GetAwaiter();
        }

        static void GetRating()
        {
            Console.WriteLine("\nPlease rate our service. 0 (terrible) to 5 (amazing).");
            Rating answer = GetEnumFromConsole();
            Console.ForegroundColor = ConsoleColor.Blue;
            switch (answer)
            {
                case Rating.Terrible: 
                case Rating.VeryBad:
                case Rating.Bad:
                    Console.WriteLine("\nOh no! IT-Academy Pizza apologize and promise to improve our service! Thanks for your rating! Waiting for you again!");
                    break;
                case Rating.SoSo:
                    Console.WriteLine("\nThanks for your rating! IT-Academy Pizza promise to improve our service! Waiting for you again!");
                    break;
                case Rating.Good:
                case Rating.Amazing:
                    Console.WriteLine("\nThanks for your rating! Waiting for you again!");
                    break;
                default:
                    Console.WriteLine("\nSorry for wasting your time. Thanks for your attention! Waiting for you again!");
                    break;
            }
            Console.ResetColor();
        }

        static Rating GetEnumFromConsole()
        {
            bool isRating = false;
            Rating rating = default;
            Console.ForegroundColor = ConsoleColor.Green;
            while (!isRating)
            {
                if (Enum.TryParse(Console.ReadLine(), out rating))
                {
                    isRating = true;
                }
                else
                {
                    break;
                }
            }
            Console.ResetColor();
            return rating;
        }

        static async Task SendEmailOrderReceive(string email, string name)
        {
            MailAddress from = new MailAddress("it-academy-minibot@mail.ru", "IT-Academy Pizza");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);
            message.Subject = $"Order received";
            message.Body = $"<h3>Hey {name}, thanks for your order №{Basket.Id}! We’ll let you know when it’s on its way.<h3>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smpt.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("it-academy-minibot@mail.ru", "OooiaeMFT23^");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }

        static void SendEmailOrderIsOnTheWay(string email, string name)
        {
            MailAddress from = new MailAddress("it-academy-minibot@mail.ru", "IT-Academy Pizza");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);
            message.Subject = $"Order delivery status - shipped";
            message.Body = $"<h3>Hey {name}, this is IT-Academy Pizza! Our driver is on the way with your order of №{Basket.Id}. <h3>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smpt.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("it-academy-minibot@mail.ru", "OooiaeMFT23^");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }

        static void SendEmailOrderDeliveredAndPaid(string email, string name)
        {
            MailAddress from = new MailAddress("it-academy-minibot@mail.ru", "IT-Academy Pizza");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);
            message.Subject = $"Order delivery status - delivered and paid";
            message.Body = $"<h3>Hey {name}, your order №{Basket.Id} has delivered and paid. Thank you! Waiting for you again!<h3>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smpt.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("it-academy-minibot@mail.ru", "OooiaeMFT23^");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}
