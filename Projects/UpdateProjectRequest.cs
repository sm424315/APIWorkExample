using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Projects
{
    public class UpdateProjectRequest
    {
        public int? Id { get; set; }
        public string ProjectNo { get; set; }
        public string Title { get; set; }
        public int? DeliveryId { get; set; }
        public string DeliveryCode { get; set; }
        public string ProjectDate { get; set; }
        public string RequiredDate { get; set; }
    }
}
