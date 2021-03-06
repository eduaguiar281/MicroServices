﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace WarehouseService.Models
{
    public enum MovementType { MoveIn, MoveOut }

    public class InventoryMovement: BaseEntity
    {
        public MovementType MovementType { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Document { get; set; }
        public string DocumentType { get; set; }
        public int ProductId { get; set; }
        public int StockPositionId { get; set; }
        public virtual Product Product { get; set; }
        public virtual StockPosition StockPosition { get; set; }
    }
}
