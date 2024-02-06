using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Stock
{
    public class StockItemPackage:BaseEntityPackageModel
    {
        public List<StockItem> Items { get; set; }
    }
}
