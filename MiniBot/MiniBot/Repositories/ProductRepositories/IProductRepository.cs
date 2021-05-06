using MiniBot.Interfaces;
using System.Collections.Generic;

namespace MiniBot.ProductRepositories
{
    interface IProductRepository<T> where T : IShowInfo
    {
        IEnumerable<T> GetProducts();
    }
}
