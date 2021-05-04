
using MiniBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    sealed class ProductViewModel
    {
        public IList<Pizza> Pizzas { get; set; }
        public IList<Drink> Drinks { get; set; }
    }
}
