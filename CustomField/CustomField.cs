using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.CustomField
{
    public class CustomField
    {
        public int? CustomFieldReferenceId { get; set; }
        public string ValueString { get; set; }
        public int? ValueNumber { get; set; }
        public string ValueDate { get; set; }
    }
}
