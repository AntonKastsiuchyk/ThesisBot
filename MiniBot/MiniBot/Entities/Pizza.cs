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

        public override string ToString()
        {
            return $"№ {Id}. {Name} \nCost {Cost:0.00}$ | Size {Size}cm | Weight {Weight}gms \n{Description}\n";
        }
    }
}
