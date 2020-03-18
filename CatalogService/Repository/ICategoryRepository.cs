using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        IQueryable<Category> Table { get; }

        Category GetCategoryByID(int categoryId);

        void InserCategory(Category category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(Category category);

        void Save();

    }
}
