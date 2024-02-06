using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Attachments
{
    public class Attachment
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string CreatedDateTime { get; set; }
        public string FileName { get; set; }
        public EnumValueAndName ModuleType { get; set; }
        public int? RecordId { get; set; }
        public string RecordNo { get; set; }
        public EnumValueAndName Type { get; set; }
        public AttachmentVisibility Visibility { get; set; }
        public string Details { get; set; }
        public string ContentType { get; set; }
        public int? SizeBytes { get; set; }
        public string Content_Base64 { get; set; }
        public string Url { get; set; }
        public string FileUri { get; set; }
    }
}
