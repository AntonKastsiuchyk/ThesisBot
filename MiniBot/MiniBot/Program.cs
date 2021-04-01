using System;
using MiniBot.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace MiniBot
{
    class Program
    {
        static void Main(string[] args)
        {
            RootProduct rootPizzas = JsonConvert.DeserializeObject<RootProduct>
                (File.ReadAllText(@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\JsonBase\Pizzas.json"));

            RootProduct root = JsonConvert.DeserializeObject<RootProduct>
                (File.ReadAllText(@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\JsonBase\Drinks.json"));
            foreach (string key in root.Drinks.Keys)
            {
                Console.WriteLine("key: " + key);
            }

            foreach (string key in rootPizzas.Pizzas.Keys)
            {
                Console.WriteLine("key: " + key);
                Pizza pizza = rootPizzas.Pizzas[key];
                Console.WriteLine($"Name {pizza.Name}");
                Console.WriteLine($"Description {pizza.Description}");

                Console.WriteLine($"Size {pizza.Size}");
                Console.WriteLine($"Cost {pizza.Cost}");
                
                Console.WriteLine();
            }
        }
    }
}
