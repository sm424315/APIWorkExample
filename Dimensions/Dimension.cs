using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Dimensions
{
    public class Dimension
    {
        public string Code { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
    }
}
