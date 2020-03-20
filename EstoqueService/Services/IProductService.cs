using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseService.Models;

namespace WarehouseService.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProductByID(int productId);

        void InsertProduct(Product product);

        void DeleteProduct(int productId);

        void UpdateProduct(Product product);

    }
}
