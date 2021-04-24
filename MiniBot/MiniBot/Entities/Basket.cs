using LogCustom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    sealed class Basket
    {
        static List<Product> _products = new List<Product>();

        public static readonly int Id = new Random().Next(100_000, 200_000);

        public float TotalPrice
        {
            get
            {
                float sum = 0;
                for (int i = 0; i < _products.Count; i++)
                {
                    sum += _products[i].Cost * _products[i].Amount;
                }
                return sum;
            }
        }

        internal void AddById(int id)
        {
            Logger.Debug("Add product to basket by Id.");
            ProductViewModel products = JsonConvert.DeserializeObject<ProductViewModel>
                (File.ReadAllText
                (@"C:\Users\user\source\repos\AntonKastsiuchyk\ITAcademy.MiniBot\MiniBot\MiniBot\bin\Debug\net5.0\JsonBase\ProductViewModel.json"));

            if (id >= 1 && id <= 30)
            {
                foreach (var pizza in products.Pizzas)
                {
                    if (id == pizza.Id)
                    {
                        if (CheckReplicant(id) == false)
                        {
                            _products.Add(pizza);
                            return;
                        }
                        return;
                    }
                }
            }

            if (id >= 31 && id <= 39)
            {
                foreach (var drink in products.Drinks)
                {
                    if (id == drink.Id)
                    {
                        if (CheckReplicant(id) == false)
                        {
                            _products.Add(drink);
                            return;
                        }
                        return;
                    }
                }
            }
        }

        internal void DeleteById(int id)
        {
            Logger.Debug("Delete product from basket by Id.");
            var product = _products.Where(i => i.Id == id).FirstOrDefault();
            _products.Remove(product);
        }

        internal IEnumerable<Product> GetProducts()
        {
            Logger.Debug("Get products from basket and show this products to user.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!CheckForEmpty())
            {
                Console.WriteLine("\nBASKET:");
                List<Product> sortedList = _products.OrderBy(i => i.Id).ToList();
                foreach (var product in sortedList)
                {
                    Console.WriteLine(product.ShowInfo());
                }
                Console.WriteLine("\nTotal price of your order: {0:0.00}$", TotalPrice);
            }
            else
            {
                Console.WriteLine("\nBASKET:\n\t Empty :(");
            }
            Console.ResetColor();
            return _products;
        }

        internal void UpdateById(int id, int amount)
        {
            Logger.Debug("Add amount to product by Id.");
            Product product = _products.Where(i => i.Id == id).FirstOrDefault();
            _products.Remove(product);
            product.Amount = amount;
            _products.Add(product);
        }

        internal static bool CheckProductAvailability(int id)
        {
            bool isProduct = false;
            Logger.Debug("Check availability of product by Id in basket.");
            Product product = _products.Where(i => i.Id == id).FirstOrDefault();
            if (product != default)
            {
                isProduct = true;
            }
            return isProduct;
        }

        internal bool CheckReplicant(int id)
        {
            bool isReplicant = false;
            Product product = _products.Where(i => i.Id == id).FirstOrDefault();

            if (product != default)
            {
                product.Amount += 1;
                isReplicant = true;
            }
            return isReplicant;
        }

        internal void ShowShortInfo()
        {
            Logger.Debug("Show short info of products to user.");
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_products[i].Name} - {_products[i].Amount} pc.");
            }
        }

        internal static bool CheckForEmpty()
        {
            bool result = false;
            if (_products.Count == 0)
            {
                result = true;
            }
            return result;
        }
    }
}
