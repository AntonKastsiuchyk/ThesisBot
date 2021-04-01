using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    class Pizza : Product
    {
        public int Size { get; set; }

        public int Weight { get; set; }

        public Pizza(string name, int id, float cost, string description, byte amount, int size, int weight)
        {
            Size = size;
            Weight = weight;
        }

        public Pizza()
        {
        }

        public override string ToString()
        {
            return $"Name {Name}, Cost {Cost}, Size {Size}, Description {Description}, Weight {Weight}";
        }
    }
}
