using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.CustomField
{
    public class SimpleCustomFieldWithValue
    {
        public int? Id { get; set; }
        public CustomFieldValue Value { get; set; }
    }
}
