using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Projects
{
    public class ProjectPackage : BaseEntityPackageModel
    {
        public List<Project> Items { get; set; }
    }
}
