using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Data
{
    public class SalesTaxCode
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsTaxable { get; set; }
        public bool? Inactive { get; set; }
    }
}
