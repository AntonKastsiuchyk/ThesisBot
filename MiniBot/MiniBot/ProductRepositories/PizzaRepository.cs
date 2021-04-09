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
        static List<Pizza> pizzas = new List<Pizza>();

        public List<Pizza> GetProducts()
        {
            ProductViewModel product = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText(@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\JsonBase\ProductViewModel.json"));

            foreach (Pizza item in product.Pizzas)
            {
                Console.WriteLine(item.ToString());
            }
            return product.Pizzas;
        }
    }
}
