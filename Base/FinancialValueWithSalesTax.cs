using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Base
{
    public class FinancialValueWithSalesTax
    {
        public decimal Net { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Gross { get; set; }
        public decimal? ForeignNet { get; set; }
        public decimal? ForeignTax { get; set; }
        public decimal? ForeignGross { get; set; }
        public Tax TaxDetails { get; set; }
        public SalesTax SalesTaxDetails { get; set; }
    }
}
