using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Result
{
    public class ResponseStatus
    {
        public string APIVersion { get; set; }
        public bool? Success { get; set; }
        public TokenStatus Token { get; set; }
        public List<string> Reasons { get; set; }
        public List<string> Exceptions { get; set; }
    }
}
