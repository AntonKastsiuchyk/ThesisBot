using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    class Product
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public float Cost { get; set; }

        public string Description { get; set; }

        public byte Amount { get; set; }

        public Product()
        {

        }

        public Product(string name, int id, float cost, string description, byte amount)
        {
            Name = name;
            Id = id;
            Cost = cost;
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Name {Name}, Cost {Cost}$, Description {Description}";
        }
    }
}
