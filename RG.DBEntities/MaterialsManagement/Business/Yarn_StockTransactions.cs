using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Yarn_StockTransactions
    {
        [Key]
        public long YarnStockTransactionID { get; set; }
        public int? DocumentTypeID { get; set; }
        public long? DocumentNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int? MRPItemCode { get; set; }
        public long? AttributeInstanceID { get; set; }
        public long? SupplierID { get; set; }
        public DateTime? MfgDate { get; set; }
        public int? BrandID { get; set; }
        public int? PackagingID { get; set; }
        public int? ConesPerProcurementUnit { get; set; }
        public int? UnitID { get; set; }
        public long? StoreLocationID { get; set; }
        public decimal? rate { get; set; }
        public long? rateUnitID { get; set; }
        public decimal? MovingAverage { get; set; }
        public decimal? TransactionQty { get; set; }
        public string BatchNo { get; set; }
        public int? ProgramTypeID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public string LotNo { get; set; }
        public int? Status { get; set; }
        public decimal? RateWRTBaseUnit { get; set; }
        public long? YarnKnittingContractID { get; set; }
        public long? KnittingJobID { get; set; }
        public int? NoOfCartons { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public long? ReqAttributeInstanceID { get; set; }
        public long? GrossID { get; set; }
        public string BagName { get; set; }
        public int? NoOfBags { get; set; }
        public long? ObcurrencyID { get; set; }
        public int? NoOfCones { get; set; }
        public int? BagTypeID { get; set; }
        public int? ConeTypeID { get; set; }
        public double? ObconversionRate { get; set; }
    }
}
