using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI;
using TharstenAPI.Models.Customers;
using TharstenAPI.Models.Enums;
using TharstenAPI.Models.Orders.SubmitOrder;
using TharstenAPI.Models.Projects;
using TharstenAPI.Models.EstimateRequest;
using TharstenAPI.Models.Dimensions;
using TharstenAPI.Models.Estimates;

namespace APITester_C
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var user = "CONFIDENTIAL";
            var appId = "CONFIDENTIAL";
            var password = new SecureString();
            password.AppendChar('P');
            password.AppendChar('a');
            password.AppendChar('s');
            password.AppendChar('s');
            var host = "CONFIDENTIAL";
            
            ITharsten api = new Tharsten(host, user, password, appId);          
            var customerCode = "CONFIDENTIAL";

            var id = Guid.NewGuid();

            var s = $"CommBlood-{DateTime.Now.ToString("MM-dd-yy HHmmss")}";

            var projectId = await api.GetCustomerProject(customerCode: customerCode, defaultName: $"Demo Project - {DateTime.Now.ToLongDateString()}", projectDate:DateTime.Now);
            var jobId = await api.CreateCustomerJob(estimateTemplateRef: "API-CommBlood", projectId: projectId, customerCode: customerCode, jobTitle: $"Demo Job - {DateTime.Now.ToLongDateString()}"); 

            Console.Write("End");
        }
    }
}
