using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Data
{
    public class SalesTaxItem
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Rate { get; set; }
        public bool? Inactive { get; set; }
        public bool? IsTaxGroup { get; set; }
    }
}
