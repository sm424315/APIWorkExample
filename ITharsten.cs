using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TharstenAPI.Models.Customers;
using TharstenAPI.Models.Enums;
using TharstenAPI.Models.EstimateRequest;
using TharstenAPI.Models.Estimates;
using TharstenAPI.Models.Jobs;
using TharstenAPI.Models.Orders;
using TharstenAPI.Models.Orders.SubmitOrder;
using TharstenAPI.Models.ProductTypes;
using TharstenAPI.Models.Projects;
using TharstenAPI.Models.Result;
using TharstenAPI.Models.Stock;

namespace TharstenAPI
{
    public interface ITharsten
    {
        string FormatDateTime(DateTime dt);
        Task<Response<CustomerPackage>> GetCustomers(string customerCode = null, string keyword = null, string dbTimeStamp = null, int[] ids = null, int? userId = null, int page = 0,
            int? pageSize = null, int[] securityGroupIds = null, bool? includeDeliveryAddresses = null, bool? includeDeleted = null, bool? includeCourierServices = null,
            CustomerSortColumn? sortColumn = null, SortDirection? sortDirection = null);
        Task<Response<OrderPackage>> GetOrders(int[] orderIds = null, string keyword = null, string[] orderNos = null, string[] customerCode = null, int[] customerId = null,
            string[] deliverycode = null, int[] deliveryId = null, DateTime? orderDateFrom = null, DateTime? orderDateTo = null, DateTime? requiredDateFrom = null, DateTime? requiredDateTo = null,
            OrderStatus[] statuses = null, int[] productIds = null, OrderSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null);
        Task<Response<SubmitOrders>> CreateOrders(SubmitOrders orders);
        Task<Response<StockItemPackage>> GetProducts(int[] ids = null, string productCode = null, string keyword = null, string customerCode = null, int? customerId = null,
            List<StockItemTypes> types = null, string stockReference1 = null, string stockReference2 = null, string stockReference3 = null, string stockReference4 = null,
            string stockReference5 = null, string stockReference6 = null, string stockReference7 = null, string stockReference8 = null, string stockReference9 = null, string stockReference10 = null,
            string sizeCode = null, string brand = null, string group = null, string color = null, string category = null, string stockType = null, string projectEstimateId = null,
            string projectTitle = null, StockItemSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null, bool? includeLocations = null,
            bool? includeAttachments = null, bool? includeBOMDetails = null, bool? isBOM = null, bool? includeGeneric = null);

        Task<Response<ProjectPackage>> GetProject(int[] ids = null, string[] projectNos = null, int? customerId = null, string customerCode = null, string customerName = null,
            string title = null, DateTime? projectDateFrom = null, DateTime? projectDateTo = null, DateTime? requiredDateFrom = null, DateTime? requiredDateTo = null,
            ProjectSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null);

        Task<Response<ProjectResponse>> CreateProject(CreateProjectRequest project);

        Task<Response<ProjectResponse>> UpdateProject(UpdateProjectRequest project);

        Task<Response<EstRequestResponse>> CreateEstimate(EstRequestProduct estRequest);

        Task<Response<ProductTypesPackage>> GetProductTypes(int[] ids = null, string name = null, ProductTypeSortColumn? sortColumn = null, SortDirection? sortDirection = null,
            int page = 0, int? pageSize = null);

        Task<Response<EstimatePackage>> GetEstimates(int[] ids = null, string keyword = null, string estimateRef = null, string dbTimeStamp = null,
            EstimateSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null,
            string customerCode = null, int? customerId = null, string jobType = null, int? productTypeId = null, DateTime? createdDateTimeFrom = null, DateTime? createdDateTimeTo = null,
            DateTime? lastModifiedDateTimeFrom = null);

        Task<Response<NewJobFromEstimateResponse>> CreateJobFromEstimate(NewJobFromEstimateRequest estRequest);

        Task<Response<UpdateEstimateResponse>> UpdateEstimate(int estimateId, UpdateEstimateRequest estRequest);

        Task<Response<JobPackage>> GetJobs(int[] ids = null, string keyword = null, string[] jobNo = null, int? projectId = null,
            string dbTimeStamp = null, string customerCode = null, int? customerId = null, string jobType = null, DateTime? createdDateTimeFrom = null,
            DateTime? createdDateTimeTo = null, DateTime? lastModifiedDateTimeFrom = null, DateTime? lastModifiedDateTimeTo = null, DateTime? requiredDateTimeFrom = null,
            DateTime? requiredDateTimeTo = null, DateTime? finishedProductionDateTimeFrom = null, DateTime? finishedProductionDateTimeTo = null,
            DateTime? completedDateTimeFrom = null, DateTime? completedDateTimeTo = null, DateTime? cancelledDateTimeFrom = null,
            DateTime? cancelledDateTimeTo = null, bool? finishedProduction = null, bool? cancelled = null,
            bool? completed = null, bool? outOnProof = null, bool? invoiced = null, bool? delivered = null, bool? produced = null,
            List<GangType> gangType = null, int? estimateId = null, string estimateHeaderRef = null, string ref1 = null, string ref2 = null,
            string ref3 = null, string ref4 = null, string ref5 = null, string ref6 = null, string ref7 = null, string ref8 = null, string ref9 = null, string ref10 = null,
            JobSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null,
            int? userId = null, int? filterId = null, DetailLevel? detailLevel = null, CostsDetailLevel? costsDetailLevel = null);

        Task<int> GetCustomerProject(string customerCode, string defaultName, int? projectId = null, DateTime? projectDate = null);

        Task<int> CreateCustomerJob(string estimateTemplateRef, int projectId, string customerCode, string jobTitle, DateTime? requiredDateTime = null, int? quantity = null, string defaultpapercode = null);
    }
}