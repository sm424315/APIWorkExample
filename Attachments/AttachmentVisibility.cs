using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Attachments
{
    public class AttachmentVisibility
    {
        public bool? IDC { get; set; }
        public bool? E4Print { get; set; }
        public bool? PrintManagement { get; set; }
        public bool? JobWatch { get; set; }
        public bool? Portal { get; set; }
    }
}
