using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Estimates
{
    public class EstimatePackage:BaseEntityPackageModel
    {
        public List<Estimate> Items { get; set; }
    }
}
