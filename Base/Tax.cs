using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Base
{
    public class Tax
    {
        public string Code { get; set; }   
        public string Description { get; set; } 
        public decimal? Rate { get; set; }
    }
}
