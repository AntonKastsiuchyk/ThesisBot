using System;
using MiniBot.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using MiniBot.Activity;
using MiniBot.ProductRepositories;
using LogCustom;
using System.Net.Mail;
using System.Net;

namespace MiniBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Debug("Start debug.");
            AssistantBot.Hello();

        Startloop:
            AssistantBot assistant = new AssistantBot();
            int answer = assistant.ShowMenuToUser();

            switch (answer)
            {
                case 1:
                    assistant.ChoosePizza();
                    break;
                case 2:
                    assistant.ChooseDrink();
                    break;
            }

            if (assistant.ShowBasketOrMenu())
            {
                goto Startloop;
            }

            assistant.ActionWithBasket();

            if (assistant.GetNewOrder())
            {
                assistant = null;
                goto Startloop;
            }

            Logger.Debug("Solution сompleted successfully.");
        }
    }
}
