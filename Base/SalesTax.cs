using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Base
{
    public class SalesTax
    {
        public int? SalesTaxCodeId { get; set; }
        public int? SalesTaxGroupId { get; set; }
        public string Description { get; set; }
        public List<SalesTaxItem> Items { get; set; }
    }
}
