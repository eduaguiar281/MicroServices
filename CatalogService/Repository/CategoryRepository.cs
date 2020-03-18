using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogService.Infrastructure.Data;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDataContext _dbContext;

        public CategoryRepository(CatalogDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Category> Table { get => _dbContext.Categories; }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _dbContext.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
            if (categoryToDelete == null)
                throw new ArgumentException("Categoria informado para exclusão não existe!", nameof(categoryId));
            _dbContext.Categories.Remove(categoryToDelete);
            Save();
        }

        public IEnumerable<Category> GetCategories()
        {
            
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryId)
        {
            var category = _dbContext.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
            if (category == null)
                throw new ArgumentException("Categoria informado não existe!", nameof(categoryId));
            return category;
        }

        public void InserCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Categoria não foi informado!");
            _dbContext.Categories.Add(category);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Categoria não foi informado!");
            _dbContext.Entry(category).State = EntityState.Modified;
            Save();
        }
    }
}
