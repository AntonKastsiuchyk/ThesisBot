using System.Collections.Generic;

namespace MiniBot.Entities
{
    sealed class ProductViewModel
    {
        public IList<Pizza> Pizzas { get; set; }
        public IList<Drink> Drinks { get; set; }
    }
}
