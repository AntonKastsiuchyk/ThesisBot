using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBot.Interfaces;

namespace MiniBot.Entities
{
    sealed class Pizza : Product
    {
        public int Size { get; set; }

        public int Weight { get; set; }

        public Pizza(string name, byte id, float cost, string description, byte amount, int size, int weight)
        {
            Size = size;
            Weight = weight;
        }

        public Pizza()
        {
        }

        public override string ToString()
        {
            return $"{Id}. {Name} \nCost {Cost}$ | Size {Size}cm | Weight {Weight}gms \n{Description}\n";
        }
    }
}
