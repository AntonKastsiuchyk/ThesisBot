using MiniBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.Repositories.BasketRepository
{
    interface IBasketRepository<T> where T : IShowInfo
    {
        IEnumerable<T> GetProducts();

        void AddById(byte id);

        void DeleteById(byte id);

        void UpdateById(byte id, byte amount);
    }
}
