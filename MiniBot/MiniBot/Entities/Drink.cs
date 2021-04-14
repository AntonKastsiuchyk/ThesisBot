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

        public Drink(string name, byte id, float cost, string description, byte amount, float volume)
        {
            Volume = volume;
        }

        public Drink()
        {
        }

        public override string ToString()
        {
            return $"{Id}. {Name} \nCost {Cost}$ | Volume {Volume}l \n{Description}\n";
        }
    }
}
