﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Models;

namespace WarehouseService.Models
{
    public enum SectorType { PrivatePlace, ThirdPlace }

    public class StockSector : BaseEntity
    {
        public string Description { get; set; }
        public bool Active { get; set; }
        public SectorType SectorType { get; set; }
        public virtual IEnumerable<StockPosition> StockPositions { get; set; }

        public override string ToString()
        {
            return $"{Id}- {Description}";
        }

    }
}
