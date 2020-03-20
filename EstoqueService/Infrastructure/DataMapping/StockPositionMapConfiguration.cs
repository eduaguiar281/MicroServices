using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseService.Models;

namespace WarehouseService.Infrastructure.DataMapping
{
    class StockPositionMapConfiguration : IEntityTypeConfiguration<StockPosition>
    {
        public void Configure(EntityTypeBuilder<StockPosition> builder)
        {
            builder.ToTable(nameof(StockPosition));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).HasMaxLength(100).HasField("_description");
            builder.Property(p => p.Street).HasMaxLength(30);
            builder.Property(p => p.Column).HasMaxLength(30);
            builder.Property(p => p.Level).HasMaxLength(30);
            builder.Property(p=> p.Availability).HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (Availability)Enum.Parse(typeof(Availability), v))
                .IsUnicode(false);
        }
    }
}
