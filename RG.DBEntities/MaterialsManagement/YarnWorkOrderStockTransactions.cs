using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWorkOrderStockTransactions
    {
        public long WorkOrderStockTransactionId { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? DocumentNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int? MrpitemCode { get; set; }
        public long? AttributeInstanceId { get; set; }
        public long? SupplierId { get; set; }
        public DateTime? MfgDate { get; set; }
        public int? BrandId { get; set; }
        public int? PackagingId { get; set; }
        public int? ConesPerProcurementUnit { get; set; }
        public int? UnitId { get; set; }
        public long? StoreLocationId { get; set; }
        public decimal? Rate { get; set; }
        public long? RateUnitId { get; set; }
        public decimal? MovingAverage { get; set; }
        public decimal? TransactionQty { get; set; }
        public string BatchNo { get; set; }
        public int? ProgramTypeId { get; set; }
        public int? OrderId { get; set; }
        public string OrderNo { get; set; }
        public string LotNo { get; set; }
        public int? Status { get; set; }
        public decimal? RateWrtbaseUnit { get; set; }
        public long? YarnIssuanceId { get; set; }
        public long? WorkOrderId { get; set; }
        public long? YarnStockTransactionId { get; set; }
        public long? WorkOrderTypeId { get; set; }
    }
}
