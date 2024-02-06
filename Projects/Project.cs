using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Customers;

namespace TharstenAPI.Models.Projects
{
    public class Project
    {
        public int? Id { get; set; }
        public string ProjectNo { get; set; }
        public string Title { get; set; }
        public Customer Customer { get; set; }
        public string ProjectDate { get; set; }
        public string RequiredDate { get; set; }
        public int? SecurityGroupId { get; set; }
        public int? CompanyId { get; set; }
    }
}
