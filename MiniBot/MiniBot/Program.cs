using System;
using MiniBot.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using MiniBot.Activity;
using MiniBot.ProductRepositories;
using LogCustom;

namespace MiniBot
{
    class Program
    {
        static void Main(string[] args)
        {
            AssistantBot.Hello();

            Startloop:
            int answer = AssistantBot.ShowMenuForUser();

            if (answer == 1)
            {
                AssistantBot.ChoosePizza();
            }
            if(answer == 2)
            {
                AssistantBot.ChooseDrink();
            }

            if(AssistantBot.ShowBasketOrMenu() == true)
            {
                goto Startloop;
            }

            AssistantBot.ActionWithBasket();
        }
    }
}
