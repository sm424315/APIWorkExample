using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Enums
{
    public class EnumDetails
    {
        public string Name { get; set; } 
        public List<EnumValue> Values { get; set; }
    }
}
