using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseService.Models;
using WarehouseService.Services;

namespace WarehouseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return _productService.GetProductByID(id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _productService.InsertProduct(value);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var product = _productService.GetProductByID(id);
            product.Name = value.Name;
            product.Description = value.Description;
            _productService.UpdateProduct(product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }

    }
}
