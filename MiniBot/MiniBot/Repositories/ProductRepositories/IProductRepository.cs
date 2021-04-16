using MiniBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBot.ProductRepositories
{
    interface IProductRepository<T>
    {
        IEnumerable<T> GetProducts();
        //T GetProductById(int id);
        //void DeleteProductById(int id);
    }
}
