﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace WarehouseService.Models
{
    public class StockBalance : BaseEntity
    {

        public int ProductId { get; set; }

        public int StockPositionId { get; set; }

        public virtual Product Product { get; set; }

        public virtual StockPosition StockPosition { get; set; }

        public int Balance { get; set; }
    }
}
