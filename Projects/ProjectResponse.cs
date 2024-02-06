using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Projects
{
    public class ProjectResponse
    {
        public Project Project { get; set; }
        public ProjectResult Result { get; set; }
    }

    public class ProjectResult 
    {
        public bool? Success { get; set; }
        public List<string> Problems { get; set; }
    }
}
