using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Estimates
{
    public class UpdateEstimateRequest
    {
        public EnumValueAndName Status { get; set; }
        public string CustomStatusDescription { get; set; }
        public int? RevisionEstimateId { get; set; }
        public int? JobId { get; set; }
        public bool? Expired { get; set; }
        public int? ProjectId { get; set; }
        public string DeliveryCode { get; set; }
    }
}
