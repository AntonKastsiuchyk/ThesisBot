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
            DrinkRepository drinkRepository = new DrinkRepository();
            drinkRepository.GetProducts();
            PizzaRepository pizzaRepository = new PizzaRepository();
            pizzaRepository.GetProducts();
            Console.WriteLine();
        }
}
}
