﻿
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
        public List<Pizza> Pizzas { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
