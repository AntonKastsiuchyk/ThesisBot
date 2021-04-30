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
            return string.Format("№ {0}. {1} \nCost {2:0.00}$ | Size {3}cm | Weight {4}gms \n{5}\n", Id, Name, Cost, Size, Weight, Description);
        }
    }
}
