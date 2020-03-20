using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace WarehouseService.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvalibleQuantity { get; set; }
        public int UnavalibleQuantity { get; set; }

        public virtual IEnumerable<StockBalance> StockBalances { get; set; }
        public virtual IEnumerable<InventoryMovement> InventoryMovements { get; set; }

        public override string ToString()
        {
            return $"{Id}- {Name}";
        }

    }
}
