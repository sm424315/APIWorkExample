using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Base
{
    public class Units
    {
        public string Code { get;set; } 
        public EnumValueAndName Type { get; set; }
        public int? UnitQuantity { get; set; }
    }
}
