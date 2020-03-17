using MicroCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroCrud.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IQueryable<Product> Table { get; }

        Product GetProductByID(int productId);

        void InsertProduct(Product product);

        void DeleteProduct(int productId);

        void UpdateProduct(Product product);

        void Save();
    }
}
