using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    class RootProduct
    {
        public Dictionary<string, Pizza> Pizzas { get; set; }
        public Dictionary<string, Drink> Drinks { get; set; }
    }
}
