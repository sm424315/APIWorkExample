using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Courier
{
    public class CourierServicePrice
    {
        public int? CourierServiceId { get; set; }
        public float? Price { get; set; }
        public bool? IsExtra { get; set; }
    }
}
