using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseService.Models;

namespace WarehouseService.Infrastructure.DataMapping
{
    class InventoryMovementMapConfiguration : IEntityTypeConfiguration<InventoryMovement>
    {
        public void Configure(EntityTypeBuilder<InventoryMovement> builder)
        {
            builder.ToTable(nameof(InventoryMovement));
            builder.HasKey(k => k.Id);
            builder.Property(p=> p.MovementType).HasConversion(
                v => v.ToString(),
                v => (MovementType)Enum.Parse(typeof(MovementType), v))
                .IsUnicode(false);

            builder.Property(p => p.Document).HasMaxLength(100);
            builder.Property(p => p.DocumentType).HasMaxLength(10);

        }
    }
}
