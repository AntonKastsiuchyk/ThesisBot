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
    class PizzaRepository : IProductRepository<Pizza>
    {
        static List<Pizza> _pizzas = new List<Pizza>();

        public IEnumerable<Pizza> GetProducts()
        {
            ProductViewModel product = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\MiniBot\MiniBot\bin\Debug\net5.0\JsonBase\ProductViewModel.json"));

            foreach (Pizza item in product.Pizzas)
            {
                Console.WriteLine(item.ToString());
            }
            _pizzas = product.Pizzas;
            return _pizzas;
        }
    }
}
