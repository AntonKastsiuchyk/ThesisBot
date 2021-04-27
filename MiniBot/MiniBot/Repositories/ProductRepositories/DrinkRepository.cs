using LogCustom;
using MiniBot.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.ProductRepositories
{
    class DrinkRepository : IProductRepository<Drink>
    {
        static List<Drink> _drinks = new List<Drink>();

        public IEnumerable<Drink> GetProducts()
        {
            Logger.Debug("Get drinks from Json and show them to user.");
            ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\MiniBot\MiniBot\bin\Debug\net5.0\JsonBase\ProductViewModel.json"));

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
