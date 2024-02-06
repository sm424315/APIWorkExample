using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Estimates
{
    public class NewJobFromEstimateRequest
    {
        public int? EstimateId { get; set; }
        public string CustomerOrderRef1 { get; set; }
        public string CustomerOrderRef2 { get; set; }
        public string RequiredDate { get; set; }
        public int? Quantity { get; set; }
        public bool? CreateJobOnly { get; set; }
    }
}
