using MiniBot.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogCustom;

namespace MiniBot.ProductRepositories
{
    class PizzaRepository : IProductRepository<Pizza>
    {
        static List<Pizza> _pizzas = new List<Pizza>();

        public IEnumerable<Pizza> GetProducts()
        {
            Logger.Debug("Get pizzas from Json and show them to user.");
            ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\MiniBot\MiniBot\bin\Debug\net5.0\JsonBase\ProductViewModel.json"));

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
