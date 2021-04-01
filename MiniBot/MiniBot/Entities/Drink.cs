using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    class Drink : Product
    {
        public float Volume { get; private set; }

        public Drink(string name, int id, float cost, string description, byte amount, float volume)
        {
            Volume = volume;
        }
        public Drink()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
