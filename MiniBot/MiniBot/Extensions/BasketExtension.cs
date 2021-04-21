using MiniBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Extensions
{
    static class BasketExtension
    {
        public static float AddDiscount(this Basket basket, Basket userBasket)
        {
            float discountResult = userBasket.TotalPrice - (userBasket.TotalPrice * 0.2f);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nSurprise! Discount for you 20 %!");
            Console.ResetColor();
            return discountResult;
        }
    }
}
