using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Estimates;

namespace TharstenAPI.Models.EstimateRequest
{
    public class EstRequestResponse
    {
        public Estimate Estimate { get; set; }
        public EstRequestResult Result { get; set; }
    }

    public class EstRequestResult
    {
        public bool? Success { get; set; }
        public List<string> Problems { get; set; }
    }
}
