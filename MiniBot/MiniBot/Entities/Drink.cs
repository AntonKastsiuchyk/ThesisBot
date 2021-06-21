using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    sealed class Drink : Product
    {
        public float Volume { get; set; }

        public override string ToString()
        {
            return $"№ {Id}. {Name} \nCost {Cost:0.00}$ | Volume {Volume}l \n{Description}\n";
        }
    }
}
