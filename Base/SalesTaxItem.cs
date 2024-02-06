using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Base
{
    public class SalesTaxItem
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Value { get; set; }
    }
}
