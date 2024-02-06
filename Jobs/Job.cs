using System.Collections.Generic;
using TharstenAPI.Models.Attachments;
using TharstenAPI.Models.Customers;
using TharstenAPI.Models.Data;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Jobs
{
    public class Job
    {
        public int? Id { get; set; }
        public string JobNo { get; set; }
        public string ParentJobNo { get; set; }
        public int? ProjectId { get; set; }
        public string Title { get; set; }
        public string CreatedDateTime { get; set; }
        public string CreatedUserName { get; set; }
        public string UpdatedDateTime { get; set; }
        public string UpdatedUserName { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string Ref4 { get; set; }
        public string Ref5 { get; set; }
        public string Ref6 { get; set; }
        public string Ref7 { get; set; }
        public string Ref8 { get; set; }
        public string Ref9 { get; set; }
        public string Ref10 { get; set; }
        public BaseCustomer InvoiceCustomer { get; set; }
        public BaseCustomer DeliveryCustomer { get; set; }
        public string CustomerRef1 { get; set; }
        public string CustoemrRef2 { get; set; }
        public string JobType { get; set; }
        public string JobTypeDescription { get; set; }
        public int? QuantityOrdered { get; set; }
        public int? QuantityDelivered { get; set; }
        public int? QuantityInvoiced { get; set; }
        public int? QuantityProduced { get; set; }
        public float? Price { get; set; }
        public float? ForeignPrice { get; set; }
        public Currency Currency { get; set; }
        public string SalesOrderNo { get; set; }
        public int? SalesOrderLineId { get; set; }
        public EnumValueAndName Status { get; set; }
        public string FinishedProductionDate { get; set; }
        public string CompletedDate { get; set; }
        public string CancelledDate { get; set; }
        public string RequiredDateTime { get; set; }
        public string LastActivityDate { get; set; }
        public string LastActivityCode { get; set; }
        public string LastActivityDescription { get; set; }
        public int? IssueNumber { get; set; }
        public bool? OutOnProof { get; set; }
        public string ProofSentDateTime { get; set; }
        public string ProofReturnedDateTime { get; set; }
        public string LastMilestone { get; set; }
        public EnumValueAndName RoleInSeries { get; set; }
        public List<JobDescription> JobDescription { get; set; }
        public int? EstimateId { get; set; }
        public string EstimateRef { get; set; }
        public string PreviousJobNo { get; set; }
        public EnumValueAndName GangType { get; set; }
        public int? ProductId { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Subjob> SubJobs { get; set; }
        public List<Job> SeriesJobs { get; set; }
        public List<JobPart> JobParts { get; set; }
        public List<JobOperation> JobOperations { get; set; }
        public List<JobCost> JobCosts { get; set; }
        public string TimeStamp { get; set; }
    }
}