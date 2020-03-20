using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseService.Models;

namespace WarehouseService.Infrastructure.DataMapping
{
    class StockSectorMapConfiguration : IEntityTypeConfiguration<StockSector>
    {
        public void Configure(EntityTypeBuilder<StockSector> builder)
        {
            builder.ToTable(nameof(StockSector));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description);
            builder.Property(e => e.SectorType)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (SectorType)Enum.Parse(typeof(SectorType), v))
                .IsUnicode(false);
        }
    }
}
