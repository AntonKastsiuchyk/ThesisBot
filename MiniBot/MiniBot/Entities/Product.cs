using MiniBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Entities
{
    [DebuggerDisplay("Id = {Id}; Amount = {Amount}")]
    class Product : IShowInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public string ShowInfo()
        {
            return $"\n\t№ {Id}. {Name}. Cost: {Cost:0.00}$. {Amount} pc.";
        }
    }
}
