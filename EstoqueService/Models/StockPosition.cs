using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseService.Models
{

    public enum Availability { Available, Unavailable }

    public class StockPosition
    {
        public int Id { get; set; }

        private string _description = string.Empty;
        public string Description
        {
            get
            {
                return _description;
            }
        }
        private string _street;
        public string Street 
        {
            get { return _street; }
            set { _street = value; ToString(); } 
        }
        private string _column;
        public string Column 
        {
            get { return _column; }
            set { _column = value; ToString(); } 
        }
        private string _level;
        public string Level 
        { 
            get { return _level; } 
            set { _level = value; ToString(); } 
        }
        public bool Active { get; set; }
        public SectorType SectorType { get; set; }
        public int StockSectorId { get; set; }
        public virtual StockSector StockSector { get; set; }

        public virtual IEnumerable<StockBalance> StockBalances { get; set; }
        public virtual IEnumerable<InventoryMovement> InventoryMovements { get; set; }

        public override string ToString()
        {
            _description = $"{_street}.{_column}.{_level }";
            return _description;
        }

    }
}
