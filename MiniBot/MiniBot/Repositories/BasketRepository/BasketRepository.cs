using MiniBot.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Repositories.BasketRepository
{
    class BasketRepository : IBasketRepository<Product>
    {
        static List<Product> _products = new List<Product>();

        public void AddById(byte id)
        {
            ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\MiniBot\MiniBot\bin\Debug\net5.0\JsonBase\ProductViewModel.json"));

            Pizza pizzaOfUser = default;
            Drink drinkOfUser = default;

            if (id >= 1 && id <= 30)
            {
                foreach (Pizza pizza in products.Pizzas)
                {
                    if (id == pizza.Id)
                    {
                        pizzaOfUser = pizza;
                        goto FlagForPizza;
                    }
                }
            }

            if(id >= 31 && id <= 39)
            {
                foreach (Drink drink in products.Drinks)
                {
                    if (id == drink.Id)
                    {
                        drinkOfUser = drink;
                        goto FlagForDrink;
                    }
                }
            }

        FlagForPizza:
            if (id == pizzaOfUser.Id)
            {
                _products.Add(pizzaOfUser);
                return;
            }

        FlagForDrink:
            if (id == drinkOfUser.Id)
            {
                _products.Add(drinkOfUser);
            }
        }

        public void DeleteById(byte id)
        {
            var product = _products.Where(i => i.Id == id).FirstOrDefault();
            _products.Remove(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product.ShowInfo());
            }
            return _products;
        }

        public void UpdateById(byte id, byte amount)
        {
            Product product = _products.Where(i => i.Id == id).FirstOrDefault();
            product.Amount = amount;
            _products.Add(product);
        }
    }
}
