using LogCustom;
using MiniBot.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MiniBot.ProductRepositories
{
    sealed class DrinkRepository : IProductRepository<Drink>
    {
        static IList<Drink> _drinks = new List<Drink>();

        public IEnumerable<Drink> GetProducts()
        {
            Logger.Debug("Get drinks from Json and show them to user.");
            ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (Support.Support.GetCurrentDirectory() + @"\JsonBase\ProductViewModel.json"));

            Console.WriteLine();
            foreach (Drink item in products.Drinks)
            {
                Console.WriteLine(item.ToString());
            }
            _drinks = products.Drinks;
            return _drinks;
        }
    }
}
