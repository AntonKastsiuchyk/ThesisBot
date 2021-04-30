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
            return string.Format("№ {0}. {1} \nCost {2:0.00}$ | Volume {3}l \n{4}\n", Id, Name, Cost, Volume, Description);
        }
    }
}
