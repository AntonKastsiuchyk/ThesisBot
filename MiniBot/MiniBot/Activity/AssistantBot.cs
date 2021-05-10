using LogCustom;
using MiniBot.Entities;
using MiniBot.ProductRepositories;
using System;
using System.Threading.Tasks;
using MiniBot.Extensions;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace MiniBot.Activity
{
    sealed class AssistantBot
    {
        Basket _basket = new Basket();
        User _user = new User();

        internal enum Rating
        {
            Terrible = 0,
            VeryBad = 1,
            Bad = 2,
            SoSo = 3,
            Good = 4,
            Amazing = 5
        }

        #region Methods
        internal static void Hello()
        {
            Logger.Debug("Greeting.");
            switch (true)
            {
                case bool morning when morning == DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 12:
                    Console.WriteLine("Good morning! Welcome to IT-Academy Pizza!");
                    break;
                case bool day when day == DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 16:
                    Console.WriteLine("Good day! Welcome to IT-Academy Pizza!");
                    break;
                case bool evening when evening == DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 22:
                    Console.WriteLine("Good evening! Welcome to IT-Academy Pizza!");
                    break;
                case bool night when night == (DateTime.Now.Hour >= 22 || DateTime.Now.Hour < 8):
                    Console.WriteLine("Good night! Welcome to IT-Academy Pizza!");
                    break;
                default:
                    Console.WriteLine("Hello! Welcome to IT-Academy Pizza!");
                    break;
            }
        }

        internal int ShowMenuToUser()
        {
            Logger.Debug("Show menu to user.");
            Console.WriteLine("\nPlease choose position from our menu, what you want to see. \n\tMenu:");
            Console.WriteLine($"\t1 - Pizzas\n\t2 - Drinks");
            return ShowProductsFromMenu();
        }

        static int ShowProductsFromMenu()
        {
            Logger.Debug("Show pizzas or drinks to user.");
        startloop:
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
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct answer. Please try again. (1 or 2)");
                    Console.ResetColor();
                    goto startloop;
            }
            return answer;
        }

        internal void ChoosePizza()
        {
        startloop:
            Logger.Debug("User choose pizza from list.");
            Console.WriteLine("\nPlease input № of product to add this product to basket." +
                "\nTo exit please input - 0.");

            Console.ForegroundColor = ConsoleColor.Green;
            int answerId = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            if (answerId >= 1 && answerId <= 30)
            {
                _basket.AddById(answerId);
                if (AddNewProductFromSameList(answerId))
                {
                    goto startloop;
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
                goto startloop;
            }
        }

        internal void ChooseDrink()
        {
        startloop:
            Logger.Debug("User choose drink from list.");
            Console.WriteLine("\nPlease input № of product to add this product to basket." +
                "\nTo exit please input - 0.");

            Console.ForegroundColor = ConsoleColor.Green;
            int answerId = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            if (answerId >= 31 && answerId <= 39)
            {
                _basket.AddById(answerId);
                if (AddNewProductFromSameList(answerId))
                {
                    goto startloop;
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
                goto startloop;
            }
        }

        bool AddNewProductFromSameList(int answerId)
        {
            bool isUserWantSomethingElse = false;
            Console.WriteLine($"\nExcellent! Product № {answerId} in your basket!" +
                    $"\nAre you want to add something to your basket from this list of menu?" +
                    "\nFor \"yes\" please input - 1\nFor \"no\" please input - 0");
        startloop:
            Console.ForegroundColor = ConsoleColor.Green;
            int answerChoice = Support.Support.GetIntFromConsole();
            Console.ResetColor();
            switch (answerChoice)
            {
                case 0:
                    break;
                case 1:
                    isUserWantSomethingElse = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct answer. Please try again. (1 or 0)");
                    Console.ResetColor();
                    goto startloop;
            }
            return isUserWantSomethingElse;
        }

        internal bool ShowBasketOrMenu()
        {
            Logger.Debug("User decide what he want to see: menu or basket.");
            bool isMenu = false;
            Console.WriteLine("\nAre you want to see your basket or want to see our menu? (1 or 0)");

        startloop:
            int answer = Support.Support.GetIntFromConsole();
            switch (answer)
            {
                case 1:
                    _basket.GetProducts();
                    break;
                case 0:
                    isMenu = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct answer. Please try again. (1 or 0)");
                    Console.ResetColor();
                    goto startloop;
            }
            return isMenu;
        }

        internal void ActionWithBasket()
        {
            Logger.Debug("User decide what he want to do with his basket.");
        startloop:
            Console.WriteLine("\nPlease choose your next step.\n\t1 - Delete position\n\t2 - Delete all positions\n\t3 - Change amount for position" +
                "\n\t4 - Return to menu\n\t5 - Submit order\n\t6 - Exit");
            Console.ForegroundColor = ConsoleColor.Green;
            int answer = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            switch (answer)
            {
                case 1:
                    DeletePositionFromBasket();
                    goto startloop;
                case 2:
                    DeleteAllFromBasket();
                    goto startloop;
                case 3:
                    ChangeAmountForPosition();
                    goto startloop;
                case 4:
                    ReturnToMenuAndChooseProduct();
                    goto startloop;
                case 5:
                    if (!Basket.CheckForEmpty())
                    {
                        SubmitOrder();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBasket is empty. Please choose another step.");
                        Console.ResetColor();
                        goto startloop;
                    }
                    break;
                case 6:
                    Logger.Debug("User decide to exit from solution.");
                    GetRating();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nHave a nice day! Goodbye!:)");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct number of step. Please try again.");
                    Console.ResetColor();
                    goto startloop;
            }
        }

        void DeletePositionFromBasket()
        {
            Logger.Debug("User delete position from basket by Id of product.");
            if (!Basket.CheckForEmpty())
            {
                Console.WriteLine("\nPlease input № of product or 0 to choose another step: ");
            startloop:
                Console.ForegroundColor = ConsoleColor.Green;
                int idOfProductForDelete = Support.Support.GetIntFromConsole();
                Console.ResetColor();

                if (idOfProductForDelete == 0)
                {
                    _basket.GetProducts();
                    return;
                }
                else if (Basket.CheckProductAvailability(idOfProductForDelete)
                    && idOfProductForDelete >= 1 && idOfProductForDelete <= 39)
                {
                    _basket.DeleteById(idOfProductForDelete);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nSuccessfully!");
                    Console.ResetColor();
                    _basket.GetProducts();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct № of product or 0 to choose another step:");
                    Console.ResetColor();
                    goto startloop;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBasket is empty. Please choose another step.");
                Console.ResetColor();
            }
        }

        void DeleteAllFromBasket()
        {
            Logger.Debug("User delete all positions from basket.");
            if (!Basket.CheckForEmpty())
            {
                Console.WriteLine("\nAre you sure?\nFor \"yes\" please input - 1\nFor \"no\" please input - 0");
                startloop:
                Console.ForegroundColor = ConsoleColor.Green;
                int answer = Support.Support.GetIntFromConsole();
                Console.ResetColor();

                switch (answer)
                {
                    case 1:
                        _basket.Reset();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nSuccessfully!");
                        Console.ResetColor();
                        _basket.GetProducts();
                        break;
                    case 0:
                        _basket.GetProducts();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPlease input correct answer. Please try again. (1 or 0)");
                        Console.ResetColor();
                        goto startloop;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBasket is empty. Please choose another step.");
                Console.ResetColor();
            }
        }

        void ChangeAmountForPosition()
        {
            Logger.Debug("User change amount of product by Id in his basket.");
            if (!Basket.CheckForEmpty())
            {
                Console.WriteLine("\nPlease input № of product or 0 to choose another step: ");
            startloop:
                Console.ForegroundColor = ConsoleColor.Green;
                int idOfProductForUpdate = Support.Support.GetIntFromConsole();
                Console.ResetColor();

                if (idOfProductForUpdate == 0)
                {
                    _basket.GetProducts();
                    return;
                }
                else if (Basket.CheckProductAvailability(idOfProductForUpdate)
                    && idOfProductForUpdate >= 1 && idOfProductForUpdate <= 39)
                {
                    Console.WriteLine("\nPlease input amount:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int amountOfUser = Support.Support.GetIntFromConsole();
                    Console.ResetColor();
                    switch (amountOfUser)
                    {
                        case 0:
                            _basket.DeleteById(idOfProductForUpdate);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nSuccessfully!");
                            Console.ResetColor();
                            _basket.GetProducts();
                            break;
                        default:
                            _basket.UpdateById(idOfProductForUpdate, amountOfUser);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nSuccessfully!");
                            Console.ResetColor();
                            _basket.GetProducts();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct № of product. Please try again.");
                    Console.ResetColor();
                    goto startloop;
                }  
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBasket is empty. Please choose another step.");
                Console.ResetColor();
            }
        }

        void SubmitOrder()
        {
            Logger.Debug("User decide to submit order.");
            _user.UserEmailContainAddress += User_UserEmailContainAddress;
            _user.GetInfoOfUser();

            if (_basket.TotalPrice > 20)
            {
                float discountOrder = _basket.AddDiscount(_basket);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Thank you for your order! \nOrder: ");
                _basket.ShowShortInfo();
                Console.WriteLine("\nTotal price of your order: {0:0.00}$", discountOrder);
                Console.WriteLine($"Address: {_user.Address}");
                Console.WriteLine($"\n{_user.Name}, please check your email {_user.Email} and check status of your order.");
                Console.ResetColor();
                GetRating();

                Thread.Sleep(3_000);
                Logger.Debug("Send second Email");
                SendEmailOrderIsOnTheWay(_user.Email, _user.Name);
                Thread.Sleep(3_000);
                Logger.Debug("Send final Email");
                SendEmailOrderDelivered(_user.Email, _user.Name);
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Thank you for your order! \nOrder №{Basket.Id}: ");
                _basket.ShowShortInfo();
                Console.WriteLine("\nTotal price of your order: {0:0.00}$", _basket.TotalPrice);
                Console.WriteLine($"Address: {_user.Address}");
                Console.WriteLine($"\n{_user.Name}, please check your email {_user.Email} and check status of your order.");
                Console.ResetColor();
                GetRating();

                Thread.Sleep(3_000);
                Logger.Debug("Send second Email");
                SendEmailOrderIsOnTheWay(_user.Email, _user.Name);
                Thread.Sleep(3_000);
                Logger.Debug("Send final Email");
                SendEmailOrderDelivered(_user.Email, _user.Name);
            }
        }

        void ReturnToMenuAndChooseProduct()
        {
            Logger.Debug("User decide to see menu again.");
            AssistantBot assistant = new AssistantBot();
        startloop:
            int answerForThisCase = ShowMenuToUser();
            if (answerForThisCase == 1)
            {
                assistant.ChoosePizza();
            }
            if (answerForThisCase == 2)
            {
                assistant.ChooseDrink();
            }
            if (assistant.ShowBasketOrMenu())
            {
                goto startloop;
            }
        }

        static void User_UserEmailContainAddress(object sender, Events.UserEmailContainAddressEventArgs user)
        {
            Logger.Debug("Start event. Send first Email");
            try
            {
                AssistantBot assistant = new AssistantBot();
                assistant.SendEmailOrderReceive(user.Email, user.Name).GetAwaiter();
            }
            catch (Exception ex)
            {
                Logger.Error($"First Email canceled - {ex.Message}.");
            }
        }

        void GetRating()
        {
            Logger.Debug("Get rating of service.");
            Console.WriteLine("\nPlease rate our service. 0 (terrible) to 5 (amazing).");

            Console.ForegroundColor = ConsoleColor.Green;
            Rating answer = GetEnumFromConsole();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            switch (answer)
            {
                case Rating.Terrible:
                case Rating.VeryBad:
                case Rating.Bad:
                    Console.WriteLine("\nOh no! IT-Academy Pizza apologize and promise to improve our service! Thanks for your rating!");
                    break;
                case Rating.SoSo:
                    Console.WriteLine("\nThanks for your rating! IT-Academy Pizza promise to improve our service!");
                    break;
                case Rating.Good:
                case Rating.Amazing:
                    Console.WriteLine("\nThanks for your rating!");
                    break;
                default:
                    Console.WriteLine("\nSorry for wasting your time. Thanks for your attention!");
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

        async Task SendEmailOrderReceive(string email, string name)
        {
            Logger.Debug("Get information of first Email.");
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

        void SendEmailOrderIsOnTheWay(string email, string name)
        {
            Logger.Debug("Get information of second Email.");
            MailAddress from = new MailAddress("it-academy-minibot@mail.ru", "IT-Academy Pizza");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);
            message.Subject = $"Order delivery status - shipped";
            message.Body = $"<h3>Hey {name}, this is IT-Academy Pizza! Our driver is on the way with your order of №{Basket.Id}. <h3>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smpt.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("it-academy-minibot@mail.ru", "OooiaeMFT23^");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Logger.Error($"Second Email canceled - {ex.Message}.");
            }
        }

        void SendEmailOrderDelivered(string email, string name)
        {
            Logger.Debug("Get information of final Email.");
            MailAddress from = new MailAddress("it-academy-minibot@mail.ru", "IT-Academy Pizza");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);
            message.Subject = $"Order delivery status - delivered and paid";
            message.Body = $"<h3>Hey {name}, your order №{Basket.Id} has delivered and paid. Thank you! Waiting for you again!<h3>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smpt.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("it-academy-minibot@mail.ru", "OooiaeMFT23^");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Logger.Error($"Third Email canceled - {ex.Message}.");
            }
        }

        internal bool GetNewOrder()
        {
            bool isNewOrder = false;
            Console.WriteLine("\nAre you want to make new order?\nFor \"yes\" please input - 1\nFor \"no\" please input - 0");
        startloop:
            Console.ForegroundColor = ConsoleColor.Green;
            int answer = Support.Support.GetIntFromConsole();
            Console.ResetColor();

            switch (answer)
            {
                case 1:
                    _basket.Reset();
                    isNewOrder = true;
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nBest wishes! See you next time!");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input correct № of product. Please try again.");
                    Console.ResetColor();
                    goto startloop;
            }
            return isNewOrder;
        }
        #endregion Methods
    }
}
