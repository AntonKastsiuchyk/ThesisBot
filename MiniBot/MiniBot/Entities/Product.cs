using MiniBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    class Product : IShowInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public Product(string name, int id, float cost, string description, int amount)
        {
            Name = name;
            Id = id;
            Cost = cost;
            Description = description;
            Amount = amount;
        }

        public string ShowInfo()
        {
            return $"\n\t№ {Id}. {Name}. Cost {Cost}$. {Amount} pc.";
        }

        public Product()
        {
        }
    }
}
