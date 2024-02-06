using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Enums
{
    public enum CustomerSortColumn
    {
        ID,
        Code,
        Name
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public enum OrderStatus
    {
        OrderEntered,
        Cancelled,
        Completed,
        AwaitingInvoice,
        Produced,
        PartialDelivery,
        AwaitingDelivery,
        PartialInvoice,
        Confirmed,
        NotSubmitted,
        AwaitingAuthorization,
        Unknown
    }

    public enum OrderSortColumn
    {
        ID,
        OrderNo,
        OrderDate,
        RequiredDate
    }

    public enum StockItemTypes
    {
        Finished,
        PrintableFlat,
        Printable_Reel,
        Origination,
        Material,
        Sundry,
        Service,
        Unknown
    }

    public enum StockItemSortColumn
    {
        Id,
        Code,
        Description
    }

    public enum ProjectSortColumn
    {
        Id,
        ProjectNo,
        Title,
        ProjectDate,
        RequiredDate
    }

    public enum ProductTypeSortColumn
    {
        Id,
        Name,
        Description
    }

    public enum EstimateSortColumn
    {
        Id,
        EstimateRef,
        Title,
        CreatedDate,
        LastModifiedDate
    }

    public enum GangType
    {
        Normal,
        Gang,
        Ganged,
        Pro,
        Unknown
    }

    public enum JobSortColumn
    {
        Id,
        JobNo,
        RequiredDate
    }

    public enum DetailLevel
    {
        Basic,
        IncludeParts,
        IncludePartsAndOperations
    }

    public enum CostsDetailLevel
    {
        None,
        IncludeCosts
    }
}
