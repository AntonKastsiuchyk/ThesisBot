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

        public Drink(string name, int id, float cost, string description, int amount, float volume)
        {
            Volume = volume;
        }

        public override string ToString()
        {
            return $"№ {Id}. {Name} \nCost {Cost}$ | Volume {Volume}l \n{Description}\n";
        }

        public Drink()
        {
        }
    }
}
