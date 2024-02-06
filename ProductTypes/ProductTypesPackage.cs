using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.ProductTypes
{
    public class ProductTypesPackage : BaseEntityPackageModel
    {
        public List<ProductType> Items { get; set; }
    }
}
