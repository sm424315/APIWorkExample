using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Data
{
    public class CarriageService
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OnlineName { get; set; }
        public string SalesTaxCode { get; set; }
        public string SalesNominal { get; set; }
        public string SalesCostCentre { get; set; }
        public string SalesDepartment { get; set; }
        public int? SalesTaxCodeId { get; set; }
        public string AvalaraTaxCode { get; set; }
    }
}
