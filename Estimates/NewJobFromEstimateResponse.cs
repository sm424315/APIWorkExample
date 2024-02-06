using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Result;

namespace TharstenAPI.Models.Estimates
{
    public class NewJobFromEstimateResponse
    {
        public bool JobCreated { get; set; }
        public ResultResponse Result { get; set; }
    }
}
