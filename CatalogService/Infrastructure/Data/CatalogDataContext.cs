﻿using CatalogService.Infrastructure.DataMapping;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Data
{
    public class CatalogDataContext: DbContext
    {
        public CatalogDataContext(DbContextOptions<CatalogDataContext> options)
            :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapConfiguration());
            modelBuilder.Entity<Category>().HasData(
              new Category
              {
                  Id = 1,
                  Name = "Electronics",
                  Description = "Electronic Items",
              },
              new Category
              {
                  Id = 2,
                  Name = "Clothes",
                  Description = "Dresses",
              },
              new Category
              {
                  Id = 3,
                  Name = "Grocery",
                  Description = "Grocery Items",
              });
        }
    }
}
