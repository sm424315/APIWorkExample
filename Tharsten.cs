using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TharstenAPI.Helpers;
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
    public class Tharsten : ITharsten
    {
        #region Fields
        private protected string _token;
        private protected DateTime? _tokenExpiration;
        private protected string _tharHost;
        private protected string _u;
        private protected SecureString _p;    
        private protected string _appId;
        #endregion

        #region Ctor
        public Tharsten(string tharstenHost, string email, SecureString password, string applicationId)
        {
            _tharHost = tharstenHost;
            _u = email;
            _p = password;
            _appId = applicationId;
        }
        #endregion

        #region Utility
        public string FormatDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH:mm:ss-05:00");
        }
        static String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }

        private protected HttpClient GetBaseTharClient()
        {
            var c = new HttpClient();
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (false == string.IsNullOrEmpty(_token))
            {
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _token);
            }
                
            return c;
        }

        private string BuildEndPointUri(string endpoint, List<string> parameters)
        {
            var parms = parameters.Where(x => false == string.IsNullOrEmpty(x)).ToList();
            if (parms.Any())
                return $"{_tharHost}/{endpoint}?{String.Join("&", parms)}";
            else
                return $"{_tharHost}/{endpoint}";
        }
        #endregion

        #region Methods
        public async Task Authenticate()
        {
            var parms = new List<string>();
            parms.Add($"email={_u}");
            parms.Add($"applicationId={_appId}");
            parms.Add($"password={SecureStringToString(_p)}");
            var endpoint = BuildEndPointUri("/api/authentication/generateapitoken", parms);

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<Credentials>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    if(result!=null)
                    {
                        if(result.Details!=null && false == string.IsNullOrEmpty(result.Details.Token))
                        {
                            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{result.Details.Token}:{SecureStringToString(_p)}");
                            _token = System.Convert.ToBase64String(plainTextBytes);
                            _tokenExpiration = DateTime.Parse(result.Details.ExpiresDateTime);
                        }
                    }
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #region Customers
        public async Task<Response<CustomerPackage>> GetCustomers(string customerCode=null, string keyword=null, string dbTimeStamp=null, int[] ids=null, int? userId = null, int page = 0,
            int? pageSize = null, int[] securityGroupIds = null, bool? includeDeliveryAddresses=null, bool? includeDeleted=null, bool? includeCourierServices = null,
            CustomerSortColumn? sortColumn = null, SortDirection? sortDirection = null)
        {
            var parms = new List<string>();
            parms.Add(ParmsHelper.ParseParm("customerCode", customerCode));
            parms.Add(ParmsHelper.ParseParm("keyword", keyword));
            parms.Add(ParmsHelper.ParseParm("dbTimeStamp", dbTimeStamp));
            parms.AddRange(ParmsHelper.ParseParm("id", ids));
            parms.Add(ParmsHelper.ParseParm("userId", userId));
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));
            parms.AddRange(ParmsHelper.ParseParm("securityGroupID", securityGroupIds));
            parms.Add(ParmsHelper.ParseParm("includeDeliveryAddresses", includeDeliveryAddresses));
            parms.Add(ParmsHelper.ParseParm("deleted", includeDeleted));
            parms.Add(ParmsHelper.ParseParm("includeCourierServices", includeCourierServices));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            var endpoint = BuildEndPointUri("/api/customers", parms);

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<CustomerPackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion
        #region Orders
        public async Task<Response<OrderPackage>> GetOrders(int[] orderIds = null, string keyword = null, string[] orderNos=null, string[] customerCode = null, int[] customerId= null,
            string[] deliverycode=null, int[] deliveryId = null, DateTime? orderDateFrom = null, DateTime? orderDateTo = null, DateTime? requiredDateFrom = null, DateTime? requiredDateTo = null,
            OrderStatus[] statuses = null, int[] productIds = null, OrderSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null)
        {
            var parms = new List<string>();
            parms.AddRange(ParmsHelper.ParseParm("orderIDs", orderIds));
            parms.Add(ParmsHelper.ParseParm("keyword", keyword));
            parms.AddRange(ParmsHelper.ParseParm("orderNos", orderNos));
            parms.AddRange(ParmsHelper.ParseParm("customerCode", customerCode));
            parms.AddRange(ParmsHelper.ParseParm("customerId", customerId));
            parms.AddRange(ParmsHelper.ParseParm("deliveryCode", deliverycode));
            parms.AddRange(ParmsHelper.ParseParm("deliveryId", deliveryId));
            parms.Add(ParmsHelper.ParseParm("orderDateFrom", orderDateFrom));
            parms.Add(ParmsHelper.ParseParm("orderDateTo", orderDateTo));
            parms.Add(ParmsHelper.ParseParm("requiredDateFrom", requiredDateFrom));
            parms.Add(ParmsHelper.ParseParm("requiredDateTo", requiredDateTo));
            if(statuses!=null && statuses.Any())
            {
                foreach (var status in statuses)
                {
                    parms.Add($"statuses={status.ToString()}");
                }
            }
            parms.AddRange(ParmsHelper.ParseParm("productIDs", productIds));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));
            var endpoint = BuildEndPointUri("/api/orders", parms);

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<OrderPackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }

        public async Task<Response<SubmitOrders>> CreateOrders(SubmitOrders orders)
        {
            var endpoint = BuildEndPointUri("/api/orders/submit", new List<string>());

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var json = JsonConvert.SerializeObject(orders, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<SubmitOrders>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion
        #region Products
        public async Task<Response<StockItemPackage>> GetProducts(int[] ids = null, string productCode = null,string keyword = null,string customerCode = null, int? customerId = null,
            List<StockItemTypes> types = null,string stockReference1 = null, string stockReference2 = null, string stockReference3 = null, string stockReference4 = null,
            string stockReference5 = null, string stockReference6 = null, string stockReference7 = null, string stockReference8 = null, string stockReference9 = null, string stockReference10 = null,
            string sizeCode = null, string brand = null,string group = null,string color = null,string category = null,string stockType = null,string projectEstimateId = null,
            string projectTitle = null,StockItemSortColumn? sortColumn = null,SortDirection? sortDirection = null,int page = 0, int? pageSize = null,bool? includeLocations = null,
            bool? includeAttachments = null,bool? includeBOMDetails = null,bool? isBOM = null,bool? includeGeneric = null)
        {
            var parms = new List<string>();
            parms.AddRange(ParmsHelper.ParseParm("id", ids));
            parms.Add(ParmsHelper.ParseParm("productCode", productCode));
            parms.Add(ParmsHelper.ParseParm("keyword", keyword));
            parms.Add(ParmsHelper.ParseParm("customerCode", customerCode));
            parms.Add(ParmsHelper.ParseParm("customerId", customerId));
            if (types != null && types.Any())
            {
                foreach (var type in types)
                {
                    parms.Add($"types={type.ToString()}");
                }
            }
            parms.Add(ParmsHelper.ParseParm("stockReference1", stockReference1));
            parms.Add(ParmsHelper.ParseParm("stockReference2", stockReference2));
            parms.Add(ParmsHelper.ParseParm("stockReference3", stockReference3));
            parms.Add(ParmsHelper.ParseParm("stockReference4", stockReference4));
            parms.Add(ParmsHelper.ParseParm("stockReference5", stockReference5));
            parms.Add(ParmsHelper.ParseParm("stockReference6", stockReference6));
            parms.Add(ParmsHelper.ParseParm("stockReference7", stockReference7));
            parms.Add(ParmsHelper.ParseParm("stockReference8", stockReference8));
            parms.Add(ParmsHelper.ParseParm("stockReference9", stockReference9));
            parms.Add(ParmsHelper.ParseParm("stockReference10", stockReference10));
            parms.Add(ParmsHelper.ParseParm("sizeCode", sizeCode));
            parms.Add(ParmsHelper.ParseParm("brand", brand));
            parms.Add(ParmsHelper.ParseParm("group", group));
            parms.Add(ParmsHelper.ParseParm("colour", color));
            parms.Add(ParmsHelper.ParseParm("category", category));
            parms.Add(ParmsHelper.ParseParm("stockType", stockType));
            parms.Add(ParmsHelper.ParseParm("projectEstimateID", projectEstimateId));
            parms.Add(ParmsHelper.ParseParm("projectTitle", projectTitle));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));
            parms.Add(ParmsHelper.ParseParm("includeLocations", includeLocations));
            parms.Add(ParmsHelper.ParseParm("includeAttachments", includeAttachments));
            parms.Add(ParmsHelper.ParseParm("includeBOMDetails", includeBOMDetails));
            parms.Add(ParmsHelper.ParseParm("isBOM", isBOM));
            parms.Add(ParmsHelper.ParseParm("includeGeneric", includeGeneric));
            
            var endpoint = BuildEndPointUri("/api/products", parms);

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<StockItemPackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion
        #region Product Types
        public async Task<Response<ProductTypesPackage>> GetProductTypes(int[] ids = null, string name = null, ProductTypeSortColumn? sortColumn = null, SortDirection? sortDirection = null, 
            int page = 0, int? pageSize = null)
        {
            var parms = new List<string>();
            parms.AddRange(ParmsHelper.ParseParm("id", ids));
            parms.Add(ParmsHelper.ParseParm("name", name));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));

            var endpoint = BuildEndPointUri("/api/producttypes", parms);

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<ProductTypesPackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion
        #region Projects
        public async Task<Response<ProjectPackage>> GetProject(int[] ids = null, string[] projectNos = null, int? customerId = null, string customerCode = null, string customerName = null,
            string title = null, DateTime? projectDateFrom = null, DateTime? projectDateTo = null, DateTime? requiredDateFrom = null, DateTime? requiredDateTo = null,
            ProjectSortColumn? sortColumn = null,SortDirection? sortDirection = null, int page = 0, int? pageSize = null)
        {
            var parms = new List<string>();
            parms.AddRange(ParmsHelper.ParseParm("id", ids));
            if (projectNos != null && projectNos.Any())
            {
                foreach (var projectNo in projectNos)
                {
                    parms.Add($"projectNo={projectNo}");
                }
            }
            parms.Add(ParmsHelper.ParseParm("customerId", customerId));
            parms.Add(ParmsHelper.ParseParm("customerCode", customerCode));
            parms.Add(ParmsHelper.ParseParm("customerName", customerName));
            parms.Add(ParmsHelper.ParseParm("title", title));
            parms.Add(ParmsHelper.ParseParm("projectDateFrom", projectDateFrom));
            parms.Add(ParmsHelper.ParseParm("projectDateTo", projectDateTo));
            parms.Add(ParmsHelper.ParseParm("requiredDateFrom", requiredDateFrom));
            parms.Add(ParmsHelper.ParseParm("requiredDateTo", requiredDateTo));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));

            var endpoint = BuildEndPointUri("/api/projects", parms);
            
            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<ProjectPackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }

        public async Task<Response<ProjectResponse>> CreateProject(CreateProjectRequest project)
        {
            var endpoint = BuildEndPointUri("/api/projects/create", new List<string>());

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var json = JsonConvert.SerializeObject(project, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<ProjectResponse>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }

        public async Task<Response<ProjectResponse>> UpdateProject(UpdateProjectRequest project)
        {
            var endpoint = BuildEndPointUri("/api/projects/update", new List<string>());

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var json = JsonConvert.SerializeObject(project, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<ProjectResponse>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion
        #region Estimates
        public async Task<Response<EstimatePackage>> GetEstimates(int[] ids = null, string keyword = null, string estimateRef = null, string dbTimeStamp = null,
            EstimateSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null,
            string customerCode = null, int? customerId = null, string jobType = null, int? productTypeId = null, DateTime? createdDateTimeFrom = null, DateTime? createdDateTimeTo = null,
            DateTime? lastModifiedDateTimeFrom = null)
        {
            var parms = new List<string>();
            parms.AddRange(ParmsHelper.ParseParm("id", ids));
            parms.Add(ParmsHelper.ParseParm("keyword", keyword));
            parms.Add(ParmsHelper.ParseParm("estimateRef", estimateRef));
            parms.Add(ParmsHelper.ParseParm("dbTimeStamp", dbTimeStamp));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));
            parms.Add(ParmsHelper.ParseParm("customerCode", customerCode));
            parms.Add(ParmsHelper.ParseParm("customerId", customerId));
            parms.Add(ParmsHelper.ParseParm("jobType", jobType));
            parms.Add(ParmsHelper.ParseParm("productTypeId", productTypeId));
            parms.Add(ParmsHelper.ParseParm("createdDateTimeFrom", createdDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("createdDateTimeTo", createdDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("lastModifiedDateTimeFrom", lastModifiedDateTimeFrom));

            var endpoint = BuildEndPointUri("/api/estimates", parms);

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<EstimatePackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }

        public async Task<Response<UpdateEstimateResponse>> UpdateEstimate(int estimateId, UpdateEstimateRequest estRequest)
        {
            var endpoint = BuildEndPointUri($"/api/estimate/{estimateId}/update", new List<string>());

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var json = JsonConvert.SerializeObject(estRequest, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<UpdateEstimateResponse>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }

        public async Task<Response<EstRequestResponse>> CreateEstimate(EstRequestProduct estRequest)
        {
            var endpoint = BuildEndPointUri("/api/estrequest", new List<string>());

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var json = JsonConvert.SerializeObject(estRequest, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<EstRequestResponse>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }

        public async Task<Response<NewJobFromEstimateResponse>> CreateJobFromEstimate(NewJobFromEstimateRequest estRequest)
        {
            var endpoint = BuildEndPointUri("/api/estimate/newjobfromestimate", new List<string>());

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var json = JsonConvert.SerializeObject(estRequest, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<NewJobFromEstimateResponse>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        public async Task<Response<EstRequestProduct>> GetSampleEstimate(int productTypeId)
        {
            var endpoint = $"{_tharHost}/api/api/estrequest/{productTypeId}/example";

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<EstRequestProduct>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion
        #region Jobs
        public async Task<Response<JobPackage>> GetJobs(int[] ids = null, string keyword = null, string[] jobNo = null, int? projectId = null,
            string dbTimeStamp = null, string customerCode = null, int? customerId = null, string jobType = null, DateTime? createdDateTimeFrom = null,
            DateTime? createdDateTimeTo = null, DateTime? lastModifiedDateTimeFrom = null, DateTime? lastModifiedDateTimeTo = null, DateTime? requiredDateTimeFrom = null,
            DateTime? requiredDateTimeTo = null, DateTime? finishedProductionDateTimeFrom = null, DateTime? finishedProductionDateTimeTo = null,
            DateTime? completedDateTimeFrom = null, DateTime? completedDateTimeTo = null, DateTime? cancelledDateTimeFrom = null,
            DateTime? cancelledDateTimeTo = null, bool? finishedProduction = null, bool? cancelled = null, 
            bool? completed = null, bool? outOnProof = null, bool? invoiced = null, bool? delivered = null, bool? produced = null,
            List<GangType> gangType = null, int? estimateId = null, string estimateHeaderRef = null, string ref1 = null, string ref2 = null,
            string ref3 = null, string ref4 = null, string ref5 = null, string ref6 = null, string ref7 = null, string ref8 = null, string ref9 = null, string ref10 = null,
            JobSortColumn? sortColumn = null, SortDirection? sortDirection = null, int page = 0, int? pageSize = null,
            int? userId = null, int? filterId = null, DetailLevel? detailLevel = null, CostsDetailLevel? costsDetailLevel = null)
        {
            var parms = new List<string>();
            parms.AddRange(ParmsHelper.ParseParm("id", ids));
            parms.Add(ParmsHelper.ParseParm("keyword", keyword));
            if (jobNo != null && jobNo.Any())
            {
                foreach (var no in jobNo)
                {
                    parms.Add($"jobNo={no}");
                }
            }
            parms.Add(ParmsHelper.ParseParm("projectId", projectId));
            parms.Add(ParmsHelper.ParseParm("dbTimeStamp", dbTimeStamp));
            parms.Add(ParmsHelper.ParseParm("customerCode", customerCode));
            parms.Add(ParmsHelper.ParseParm("customerId", customerId));
            parms.Add(ParmsHelper.ParseParm("jobType", jobType));
            parms.Add(ParmsHelper.ParseParm("createdDateTimeFrom", createdDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("createdDateTimeTo", createdDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("lastModifiedDateTimeFrom", lastModifiedDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("lastModifiedDateTimeTo", lastModifiedDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("requiredDateTimeFrom", requiredDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("requiredDateTimeTo", requiredDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("finishedProductionDateTimeFrom", finishedProductionDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("finishedProductionDateTimeTo", finishedProductionDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("completedDateTimeFrom", completedDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("completedDateTimeTo", completedDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("cancelledDateTimeFrom", cancelledDateTimeFrom));
            parms.Add(ParmsHelper.ParseParm("cancelledDateTimeTo", cancelledDateTimeTo));
            parms.Add(ParmsHelper.ParseParm("finishedProduction", finishedProduction));
            parms.Add(ParmsHelper.ParseParm("cancelled", cancelled));
            parms.Add(ParmsHelper.ParseParm("completed", completed));
            parms.Add(ParmsHelper.ParseParm("outOnProof", outOnProof));
            parms.Add(ParmsHelper.ParseParm("invoiced", invoiced));
            parms.Add(ParmsHelper.ParseParm("delivered", delivered));
            parms.Add(ParmsHelper.ParseParm("produced", produced));
            if (gangType != null && gangType.Any())
            {
                foreach (var gt in gangType)
                {
                    parms.Add($"gangeType={gt.ToString()}");
                }
            }
            parms.Add(ParmsHelper.ParseParm("estimateId", estimateId));
            parms.Add(ParmsHelper.ParseParm("estimateHeaderRef", estimateHeaderRef));
            parms.Add(ParmsHelper.ParseParm("ref1", ref1));
            parms.Add(ParmsHelper.ParseParm("ref2", ref2));
            parms.Add(ParmsHelper.ParseParm("ref3", ref3));
            parms.Add(ParmsHelper.ParseParm("ref4", ref4));
            parms.Add(ParmsHelper.ParseParm("ref5", ref5));
            parms.Add(ParmsHelper.ParseParm("ref6", ref6));
            parms.Add(ParmsHelper.ParseParm("ref7", ref7));
            parms.Add(ParmsHelper.ParseParm("ref8", ref8));
            parms.Add(ParmsHelper.ParseParm("ref9", ref9));
            parms.Add(ParmsHelper.ParseParm("ref10", ref10));
            parms.Add(sortColumn.HasValue ? $"sortColumn={sortColumn.Value.ToString()}" : string.Empty);
            parms.Add(sortDirection.HasValue ? $"sortDirection={sortDirection.Value.ToString()}" : string.Empty);
            parms.Add($"paging_startIndex={page}");
            parms.Add(ParmsHelper.ParseParm("paging_numberOfRecords", pageSize));
            parms.Add(ParmsHelper.ParseParm("userId", userId));
            parms.Add(ParmsHelper.ParseParm("filterId", filterId));
            parms.Add(detailLevel.HasValue ? $"detailLevel={detailLevel.Value.ToString()}" : string.Empty);
            parms.Add(costsDetailLevel.HasValue ? $"costsDetailLevel={costsDetailLevel.Value.ToString()}" : string.Empty);


            var endpoint = BuildEndPointUri("/api/jobs", parms);

            await ValidateToken();

            using (var client = GetBaseTharClient())
            {
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<JobPackage>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    return result;
                }
                else
                {
                    var x = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(response.ReasonPhrase, new Exception(x));
                }
            }
        }
        #endregion

        #region Helpers
        public async Task<int> GetCustomerProject(string customerCode, string defaultName, int? projectId = null, DateTime? projectDate = null)
        {
            if (string.IsNullOrEmpty(customerCode))
                throw new ArgumentException("customerCode required");

            if (string.IsNullOrEmpty(defaultName))
                throw new ArgumentException("defaultName required");

            Response<ProjectPackage> projresult = null;


            if(projectId.HasValue && projectId.Value!=0)
                projresult = await GetProject(customerCode: customerCode, projectDateFrom: projectDate, ids: new int[] {projectId.Value});
            else
                projresult = await GetProject(customerCode: customerCode, projectDateFrom: projectDate);


            var retProjectId = 0;
            if (projresult == null || !projresult.Details.Items.Any())
            {
                var customer = await GetCustomers(customerCode: customerCode);
                if (customer.Details!=null && customer.Details.Items.Any())
                {
                    var cresult = customer.Details.Items.FirstOrDefault();

                    var projRequest = new CreateProjectRequest
                    {
                        CustomerId = cresult.ID,
                        Title = defaultName
                    };
                    var cprojresult = await CreateProject(projRequest);

                    if (cprojresult.Details != null && cprojresult.Details.Project != null && cprojresult.Details.Project.Id.HasValue)
                        retProjectId = cprojresult.Details.Project.Id.Value;
                    else
                        throw new Exception($"Error creating project - {cprojresult.Status.Reasons}");
                }
                else
                    throw new Exception($"No customers found for customer code {customerCode}");
            }
            else
            {
                if (projresult.Details != null && projresult.Details.Items.Any())
                    retProjectId = projresult.Details.Items.First().Id.Value;
                else
                    throw new Exception($"No projects found for customer code {customerCode}");
            }
            return retProjectId;
        }

        public async Task<int> CreateCustomerJob(string estimateTemplateRef, int projectId, string customerCode, string jobTitle, DateTime? requiredDateTime = null, int? quantity = null, string defaultpapercode = null)
        {
            int? jobId = 0;

            if (string.IsNullOrEmpty(customerCode))
                throw new ArgumentException("customerCode required");

            if (string.IsNullOrEmpty(estimateTemplateRef))
                throw new ArgumentException("estimateTemplateRef required");

            var eresult = await GetEstimates(estimateRef: estimateTemplateRef);
            if (eresult.Details == null || !eresult.Details.Items.Any())
                throw new Exception($"No estimate templates found for {estimateTemplateRef}");

            var etemplate = eresult.Details.Items.FirstOrDefault();

            //Estimate
            var eTempPart = etemplate.Parts.First();
            var estimateId = 0;
            var estimateQuantity = 1;
            var estRequest = new EstRequestProduct
            {
                Title = jobTitle,
                ProductTypeId = etemplate.ProductTypeId,
                FinishedSize = eTempPart.FinishedSize,
                Quantity = quantity ?? etemplate.Quantity ?? 1,
                RequiredDateTime = requiredDateTime.HasValue?requiredDateTime.Value.ToString("yyyy-MM-ddThh:mm:ss.000-04:00") : DateTime.Now.AddDays(7).ToString("yyyy-MM-ddThh:mm:ss.000-04:00"),
                Customer = new BaseCustomer { Code = customerCode },
                DeliveryCustomer = new BaseCustomer { Code = customerCode },
                ProjectId = projectId,
                Parts = BuildPartsArr(defaultpapercode, eTempPart)

            };
            var estresult = await CreateEstimate(estRequest);
            estimateId = estresult.Details.Estimate?.Id ?? 0;
            estimateQuantity = estresult.Details.Estimate?.Quantity ?? 1;

            //Job
            if (estimateId != 0)
            {
                var request = new NewJobFromEstimateRequest
                {
                    CreateJobOnly = true,
                    RequiredDate = requiredDateTime.HasValue ? requiredDateTime.Value.ToString("yyyy-MM-ddThh:mm:ss.000-04:00") : DateTime.Now.AddDays(7).ToString("yyyy-MM-ddThh:mm:ss.000-04:00"),
                    EstimateId = estimateId,
                    Quantity = quantity ?? estimateQuantity
                };
                var jobCreateResult = await CreateJobFromEstimate(request);

                if (jobCreateResult.Details != null && jobCreateResult.Details.Result != null)
                {
                    if (jobCreateResult.Details.JobCreated)
                    {
                        var jobResult = await GetJobs(estimateId: estimateId);
                        if (jobResult.Details != null && jobResult.Details.Items.Any())
                        {
                            jobId = Convert.ToInt32(jobResult.Details.Items.FirstOrDefault().JobNo);
                        }
                        else
                        {
                            var retryAttempts = 0;
                            while(retryAttempts < 30 && (false==jobId.HasValue || jobId.Value==0))
                            {
                                await Task.Delay(1000);  //if not found let SQL catchup and try again
                                jobResult = await GetJobs(estimateId: estimateId);
                                if (jobResult.Details != null && jobResult.Details.Items.Any())
                                {
                                    jobId = Convert.ToInt32(jobResult.Details.Items.FirstOrDefault().JobNo);
                                }
                                retryAttempts++;
                            }
                            
                            if(false==jobId.HasValue || jobId.Value==0)
                                throw new Exception($"No job found for estimateId {estimateId}");
                        }
                            
                    }
                    else
                        throw new Exception($"Error creating job - {String.Join(",", jobCreateResult.Details.Result.Problems)}");
                }
                else
                    throw new Exception("Error creating job");
            }
            else
                throw new Exception("Failed to generate estimate which is required for a job");

            return jobId??0;
        }

        private List<EstRequestPart> BuildPartsArr(string defaultpapercode, EstimatePart eTempPart)
        {
            if (string.IsNullOrEmpty(defaultpapercode))
            {
                return new List<EstRequestPart>
                {
                    new EstRequestPart
                    {
                        ProductTypePartId = eTempPart.ProductTypePartId,
                        //PaperCode = defaultpapercode, //- should flow through from default paper code on part
                        FinishedSize = eTempPart.FinishedSize,
                    }
                };
              
            }
            else
            {
                return new List<EstRequestPart>
                {
                    new EstRequestPart
                    {
                        ProductTypePartId = eTempPart.ProductTypePartId,
                        PaperCode = defaultpapercode, //- should flow through from default paper code on part
                        FinishedSize = eTempPart.FinishedSize,
                    }
                };
            }
        }
        #endregion
        private async Task ValidateToken()
        {
            if(true==string.IsNullOrEmpty(_token) || (_tokenExpiration.HasValue && DateTime.Now > _tokenExpiration.Value))
            {
                await this.Authenticate();
            }
        }
        #endregion
    }
}
