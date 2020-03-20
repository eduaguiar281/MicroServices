using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseService.Models;

namespace WarehouseService.Infrastructure.DataMapping
{
    class StockBalanceMapConfiguration : IEntityTypeConfiguration<StockBalance>
    {
        public void Configure(EntityTypeBuilder<StockBalance> builder)
        {
            builder.ToTable(nameof(StockBalance));
            builder.HasKey(k => k.Id);
        }
    }
}
