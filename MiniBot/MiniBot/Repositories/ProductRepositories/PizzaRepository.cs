using MiniBot.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using LogCustom;

namespace MiniBot.ProductRepositories
{
    sealed class PizzaRepository : IProductRepository<Pizza>
    {
        static IList<Pizza> _pizzas = new List<Pizza>();

        public IEnumerable<Pizza> GetProducts()
        {
            Logger.Debug("Get pizzas from Json and show them to user.");
            ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (Support.Support.GetCurrentDirectory() + @"\JsonBase\ProductViewModel.json"));

            Console.WriteLine();
            foreach (Pizza item in products.Pizzas)
            {
                Console.WriteLine(item.ToString());
            }
            _pizzas = products.Pizzas;
            return _pizzas;
        }
    }
}
