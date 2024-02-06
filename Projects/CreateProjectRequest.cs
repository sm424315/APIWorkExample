using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Projects
{
    public class CreateProjectRequest
    {
        public int? CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string Title { get; set; }
        public int? DeliveryId { get; set; }
        public string DeliveryCode { get; set; }
        public string CreatedDate { get; set; }
        public string RequiredDate { get; set; }
    }
}
