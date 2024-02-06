using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.CustomField
{
    public class CustomFieldPackage
    {
        public int? TotalItemCount { get; set; }
        public int? ReturnedItemCount { get; set; }
        public string TimeStamp { get; set; }
        public EnumValueAndName ModuleType { get; set; }
        public List<CustomField> Items { get; set; }
        public bool? Success { get; set; }
        public List<string> Reasons { get; set; }
        public List<object> Exceptions { get; set; }
    }
}
