﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public override string ToString()
        {
            return $"{Id}- {Name}";
        }
    }
}
