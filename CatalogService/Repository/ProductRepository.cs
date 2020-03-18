using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogService.Infrastructure.Data;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDataContext _dbContext;

        public ProductRepository(CatalogDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> Table { get => _dbContext.Products;  }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _dbContext.Products.Where(x => x.Id == productId).FirstOrDefault();
            if (productToDelete == null)
                throw new ArgumentException("Produto informado para exclusão não existe!", nameof(productId));
            _dbContext.Products.Remove(productToDelete);
            Save();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductByID(int productId)
        {
            var product = _dbContext.Products.Where(x => x.Id == productId).FirstOrDefault();
            if (product == null)
                throw new ArgumentException("Produto informado não existe!", nameof(productId));
            return product;
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Produto para inclusão não foi informado!");
            _dbContext.Products.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Produto para inclusão não foi informado!");
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
