using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueService.Models
{
    public class StockBalance
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int StockPositionId { get; set; }

        public virtual Product Product { get; set; }

        public virtual StockPosition StockPosition { get; set; }


    }
}
