using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Courier
{
    public class CourierType
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public EnumValueAndName Type { get; set; }
        public List<CourierTypeProperty> Properties { get; set; }
    }
}
