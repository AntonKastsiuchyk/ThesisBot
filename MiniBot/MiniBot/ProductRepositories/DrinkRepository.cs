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
        static List<Drink> drinks = new List<Drink>();

        public List<Drink> GetProducts()
        {
            ProductViewModel product = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText(@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\JsonBase\ProductViewModel.json"));

            foreach (Drink item in product.Drinks)
            {
                Console.WriteLine(item.ToString());
            }
            return product.Drinks;
        }

    }
}
