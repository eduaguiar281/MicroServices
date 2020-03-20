using CatalogService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.DataMapping
{
    class ProductMapConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Name).HasMaxLength(100);
        }
    }
}
