using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Data;
using WarehouseService.Models;

namespace WarehouseService.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _productRepository.Table.Where(x => x.Id == productId).FirstOrDefault();
            if (productToDelete == null)
                throw new ArgumentException($"Produto informado - ID:{productId} para exclusão não existe!", nameof(productId));
            _productRepository.Delete(productToDelete);
        }

        public Product GetProductByID(int productId)
        {
            var product = _productRepository.Table.Where(x => x.Id == productId).FirstOrDefault();
            if (product == null)
                throw new ArgumentException($"Produto informado - ID:{productId} não existe!", nameof(productId));
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.Table.ToList();
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Produto para inclusão não foi informado!");
            _productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Produto para alteração não foi informado!");
            _productRepository.Update(product);
        }
    }
}
